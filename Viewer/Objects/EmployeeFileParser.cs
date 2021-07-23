using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Viewer.Objects
{
    class EmployeeFileParser
    {
        const int DATA_LINE_OFFSET = 4;
        Regex _lineValidation = new Regex(@"^(\d|\;)+$");
        CsvFileReader _fileReader;
        public EmployeeFileParser(CsvFileReader fileReader)
        {
            _fileReader = fileReader;
        }
        public EmployeeFileLine[] Parse()
        {
            List<EmployeeFileLine> data = new List<EmployeeFileLine>(50000);
            CsvLine csvLine = null;
            SetFileReadOffset(_fileReader);
            while (!_fileReader.EndOfFile)
            {
                csvLine = _fileReader.ReadLine(true);
                if (IsValidLine(csvLine.Line))
                    data.Add(ParseLine(csvLine));
            }
            return data.ToArray();
        }
        EmployeeFileLine ParseLine(CsvLine csvLine)
        {
            EmployeeFileLine employeeLine = new EmployeeFileLine();
            employeeLine.LegalCompanyCode = csvLine.GetLong(0);
            employeeLine.InsurerCode = csvLine.GetLong(1);
            employeeLine.EmployeeCount = csvLine.GetLong(2);
            return employeeLine;
        }
        bool IsValidLine(string line)
        {
            return _lineValidation.IsMatch(line);
        }
        void SetFileReadOffset(CsvFileReader fileReader)
        {
            fileReader.Reset();
            for (int i = 0; i < DATA_LINE_OFFSET - 1; i++)
                fileReader.ReadLine();
        }
    }
    public class EmployeeFileLine
    {
        public long? InsurerCode { get; set; }
        public long? LegalCompanyCode { get; set; }
        public long? EmployeeCount { get; set; }
    }
}
