using System;
using System.IO;
using System.Threading.Tasks;

namespace Viewer.Objects
{
    public class ParallelCsvFileReader
    {
        const int MAX_LOAD_SIZE = 100 * 1000 * 1000, BUFFER_SIZE = 5 * 1000 * 1000;
        FileInfo _fileInfo;
        public ParallelCsvFileReader(string filePath)
        {
            _fileInfo = new FileInfo(filePath);
            if (!_fileInfo.Exists)
                throw new Exception($"Csv file '{filePath}' doesn't exist");
        }
        public void ReadLines(Action<CsvLine> actionWithReadedLine, bool eliminateSpaces = false)
        {
            Parallel.ForEach(File.ReadLines(_fileInfo.FullName), textLine =>
            {
                var csvLine = new CsvLine(textLine, eliminateSpaces);
                actionWithReadedLine?.Invoke(csvLine);
            });
        }
    }
    public class CsvFileReader : IDisposable
    {
        const int MAX_LOAD_SIZE = 100 * 1000 * 1000, BUFFER_SIZE = 5 * 1000 * 1000;
        FileInfo _fileInfo;
        StreamReader _reader;
        public CsvFileReader(string filePath)
        {
            _fileInfo = new FileInfo(filePath);
            if (!_fileInfo.Exists)
                throw new Exception($"Csv file '{filePath}' doesn't exist");
            if (_fileInfo.Length <= MAX_LOAD_SIZE)
                _reader = new StreamReader(LoadFileToMemory(_fileInfo));
            else _reader = _fileInfo.OpenText();
        }
        public void Reset()
        {
            _reader.BaseStream.Seek(0, SeekOrigin.Begin);
        }
        public bool EndOfFile
        {
           get { return _reader.EndOfStream; }
        }
        public CsvLine ReadLine(bool eliminateSpaces = false)
        {
            return new CsvLine(_reader.ReadLine(), eliminateSpaces);
        }
        public void Close()
        {
            _reader.Close();
            _reader.Dispose();
        }
        public void Dispose()
        {
            Close();
        }
        MemoryStream LoadFileToMemory(FileInfo fileInfo)
        {
            MemoryStream ms = new MemoryStream((int)fileInfo.Length);
            byte[] buffer = new byte[BUFFER_SIZE];
            using (FileStream fs = fileInfo.OpenRead())
            {
                fs.Seek(0, SeekOrigin.Begin);
                int readedBytes = 0;
                while ((readedBytes = fs.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, readedBytes);
            }
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }
    }
    public class CsvLine
    {
        const char SEPARATOR = ';';
        string[] _values;
        public string Line { get; private set; }
        public CsvLine(string line, bool eliminateSpaces)
        {
            if (line == null)
                throw new ArgumentNullException("Line argument cannot be null");
            Line = line;
            _values = Prepare(Line, eliminateSpaces);
        }
        string[] Prepare(string line, bool eliminateSpaces)
        {
            if (eliminateSpaces)
                line = line.Replace(" ", "");
            return line.Split(SEPARATOR);
        }
        public string GetString(int index, string defaultValue = "")
        {
            if (index >= _values.Length)
                return defaultValue;
            string value = _values[index];
            return HasQuotes(value) ? RemoveQuotes(value) : value;
        }
        public long? GetLong(int index, long? defaultValue = null)
        {
            string valueString = GetString(index, null);
            long value;
            if (valueString != null && long.TryParse(valueString, out value))
                return value;
            return defaultValue;
        }
        public double? GetDouble(int index, double? defaultValue = null)
        {
            string valueString = GetString(index, null);
            double value;
            if (valueString != null && double.TryParse(valueString, out value))
                return value;
            return defaultValue;
        }
        protected bool HasQuotes(string text)
        {
            return text.Length > 1 && ((text[0] == '"' && text[text.Length - 1] == '"') || (text[0] == '\'' && text[text.Length - 1] == '\''));
        }
        protected string RemoveQuotes(string text)
        {
            return text.Substring(1, text.Length - 2);
        }
    }
}
