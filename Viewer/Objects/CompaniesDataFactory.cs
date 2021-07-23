using System;
using System.IO;
using System.Threading.Tasks;

namespace Viewer.Objects
{
    public class CompaniesDataFactory
    {
        public CompaniesData Create(SalaryFileLine[] salaries, EmployeeFileLine[] employeeCounts, CompanyInfoLine[] companyInfos)
        {
            CompaniesData list = new CompaniesData();
            Parallel.For(0, salaries.Length, i =>
            {
                SalaryFileLine salary = salaries[i];
                CompanyData data = new CompanyData();
                data.LegalCompanyCode = salary.LegalCompanyCode;
                data.InsurerCode = salary.InsurerCode;
                data.AllWorkersSalary = new SalaryData()
                {
                    AverageSalary = salary.AverageSalaryAll,
                    AverageSalaryWomen = salary.AverageSalaryWomenAll,
                    AverageSalaryMen = salary.AverageSalaryMenAll,
                    Median = salary.MedianAll,
                    Quintile25 = salary.Quintile25All,
                    Quintile75 = salary.Quintile75All,
                    StandardDeviation = salary.StandardDeviationAll
                };
                data.FullDayWorkersSalary = new SalaryData()
                {
                    AverageSalary = salary.AverageSalary,
                    AverageSalaryWomen = salary.AverageSalaryWomen,
                    AverageSalaryMen = salary.AverageSalaryMen,
                    Median = salary.Median,
                    Quintile25 = salary.Quintile25,
                    Quintile75 = salary.Quintile75,
                    StandardDeviation = salary.StandardDeviation
                };
                for (int j = 0; j < employeeCounts.Length; j++)
                {
                    EmployeeFileLine employeeCount = employeeCounts[j];
                    if (employeeCount.LegalCompanyCode == data.LegalCompanyCode && employeeCount.InsurerCode == data.InsurerCode)
                    {
                        data.EmployeeCount = employeeCount.EmployeeCount;
                        break;
                    }
                }
                for (int j = 0; j < companyInfos.Length; j++)
                {
                    CompanyInfoLine companyInfo = companyInfos[j];
                    if (companyInfo.LegalCompanyCode == data.LegalCompanyCode && companyInfo.InsurerCode == data.InsurerCode)
                    {
                        data.Name = companyInfo.Name;
                        data.Municipality = companyInfo.Municipality;
                        data.EconomicActivity = companyInfo.EconomicActivity;
                        break;
                    }
                }
                lock (list)
                    list.Add(data);
            });
            return list;
        }
    }
}
