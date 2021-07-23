using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Viewer.Objects
{
    public class SalaryFileParser
    {
        const int DATA_LINE_OFFSET = 14;
        Regex _lineValidation = new Regex(@"^(\d|\s|\,|\;)+$");
        CsvFileReader _fileReader;
        public SalaryFileParser(CsvFileReader fileReader)
        {
            _fileReader = fileReader;
        }
        public SalaryFileLine[] Parse()
        {
            List<SalaryFileLine> data = new List<SalaryFileLine>(50000);
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
        SalaryFileLine ParseLine(CsvLine csvLine)
        {
            SalaryFileLine salaryLine = new SalaryFileLine();
            salaryLine.LegalCompanyCode = csvLine.GetLong(0);
            salaryLine.InsurerCode = csvLine.GetLong(1);
            salaryLine.AverageSalaryAll = csvLine.GetDouble(2);
            salaryLine.AverageSalaryWomenAll = csvLine.GetDouble(3);
            salaryLine.AverageSalaryMenAll = csvLine.GetDouble(4);
            salaryLine.MedianAll = csvLine.GetDouble(5);
            salaryLine.Quintile25All = csvLine.GetDouble(6);
            salaryLine.Quintile75All = csvLine.GetDouble(7);
            salaryLine.StandardDeviationAll = csvLine.GetDouble(8);
            salaryLine.AverageSalary = csvLine.GetDouble(9);
            salaryLine.AverageSalaryWomen = csvLine.GetDouble(10);
            salaryLine.AverageSalaryMen = csvLine.GetDouble(11);
            salaryLine.Median = csvLine.GetDouble(12);
            salaryLine.Quintile25 = csvLine.GetDouble(13);
            salaryLine.Quintile75 = csvLine.GetDouble(14);
            salaryLine.StandardDeviation = csvLine.GetDouble(15);
            return salaryLine;
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
    public class SalaryFileLine
    {
        public long? InsurerCode { get; set; }
        public long? LegalCompanyCode { get; set; }
        public double? AverageSalaryAll { get; set; }
        public double? AverageSalaryWomenAll { get; set; }
        public double? AverageSalaryMenAll { get; set; }
        public double? MedianAll { get; set; }
        public double? Quintile25All { get; set; }
        public double? Quintile75All { get; set; }
        public double? StandardDeviationAll { get; set; }
        public double? AverageSalary { get; set; }
        public double? AverageSalaryWomen { get; set; }
        public double? AverageSalaryMen { get; set; }
        public double? Median { get; set; }
        public double? Quintile25 { get; set; }
        public double? Quintile75 { get; set; }
        public double? StandardDeviation { get; set; }
    }
}
