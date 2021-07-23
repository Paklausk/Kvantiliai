using System;

namespace Viewer.Objects
{
    public class CompanyData
    {
        public long? InsurerCode { get; set; }
        public long? LegalCompanyCode { get; set; }
        public string Name { get; set; }
        public EconomicActivity EconomicActivity { get; set; }
        public Municipality Municipality { get; set; }
        public long? EmployeeCount { get; set; }
        public SalaryData AllWorkersSalary { get; set; }
        public SalaryData FullDayWorkersSalary { get; set; }
        public override string ToString()
        {
            return Name ?? "";
        }
    }
}
