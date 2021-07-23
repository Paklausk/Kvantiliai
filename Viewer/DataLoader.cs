using Viewer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer
{
    public class DataLoader
    {
        public CompaniesData Load(string salariesFilePath, string employeeCountFilePath, string companiesInfoFilePath)
        {
            SalaryFileLine[] salaryLines = null;
            EmployeeFileLine[] employeeLines = null;
            CompanyInfoLine[] companyInfoLines = null;
            Parallel.Invoke(() => {
                SalaryFileParser _salaryParser = new SalaryFileParser(new CsvFileReader(salariesFilePath));
                salaryLines = _salaryParser.Parse();
            }, () => {
                EmployeeFileParser _employeeParser = new EmployeeFileParser(new CsvFileReader(employeeCountFilePath));
                employeeLines = _employeeParser.Parse();
            }, () => {
                var _companyParser = new CompanyInfoFileParser(new CsvFileReader(companiesInfoFilePath));
                companyInfoLines = _companyParser.Parse();
                var municipalityList = new MunicipalityManager().Convert(companyInfoLines);
                var economicActivityList = new EconomicActivityManager().Convert(companyInfoLines);
            });
            var companiesData = new CompaniesDataFactory().Create(salaryLines, employeeLines, companyInfoLines);
            return companiesData;
        }
    }
}
