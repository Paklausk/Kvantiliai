using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Viewer.Objects
{
    public class CompanyInfoFileParser
    {
        const int DATA_LINE_OFFSET = 2;
        Regex _lineValidation = new Regex(@"^\d*\;\d*\;.*\;.*\;.*$");
        CsvFileReader _fileReader;
        CompanyInfoLine _lastLine;
        public CompanyInfoFileParser(CsvFileReader fileReader)
        {
            _fileReader = fileReader;
        }
        public CompanyInfoLine[] Parse()
        {
            List<CompanyInfoLine> data = new List<CompanyInfoLine>(50000);
            CsvLine csvLine = null;
            SetFileReadOffset(_fileReader);
            while (!_fileReader.EndOfFile)
            {
                csvLine = _fileReader.ReadLine();
                if (IsValidLine(csvLine.Line))
                {
                    var newLine = ParseLine(csvLine);
                    if (!newLine.Equals(_lastLine))
                    {
                        _lastLine = newLine;
                        data.Add(newLine);
                    }
                }
            }
            return data.ToArray();
        }
        CompanyInfoLine ParseLine(CsvLine csvLine)
        {
            CompanyInfoLine companyInfo = new CompanyInfoLine();
            companyInfo.LegalCompanyCode = csvLine.GetLong(1);
            companyInfo.InsurerCode = csvLine.GetLong(0);
            companyInfo.Name = csvLine.GetString(2);
            companyInfo.MunicipalityName = csvLine.GetString(3);
            companyInfo.EconomicActivityCode = csvLine.GetLong(4);
            companyInfo.EconomicActivityName = csvLine.GetString(5);
            return companyInfo;
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
    public class CompanyInfoLine
    {
        public long? InsurerCode { get; set; }
        public long? LegalCompanyCode { get; set; }
        public string Name { get; set; }
        public string MunicipalityName { get; set; }
        public long? EconomicActivityCode { get; set; }
        public string EconomicActivityName { get; set; }
        public Municipality Municipality { get; set; }
        public EconomicActivity EconomicActivity { get; set; }
        public override bool Equals(object obj)
        {
            if (!(obj is CompanyInfoLine) || obj == null)
                return false;
            else if (obj == this)
                return true;
            CompanyInfoLine line = (CompanyInfoLine)obj;
            if (InsurerCode != line.InsurerCode)
                return false;
            if (LegalCompanyCode != line.LegalCompanyCode)
                return false;
            if (Name != line.Name)
                return false;
            if (MunicipalityName != line.MunicipalityName)
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
