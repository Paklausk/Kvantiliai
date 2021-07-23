using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Objects;

namespace Viewer.DataFormatters
{
    public class TextCompanyDataFormatter : ICompanyDataFormatter
    {
        public string Format(CompanyData data)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {data.Name}");
            sb.AppendLine($"Employees: {data.EmployeeCount}");
            sb.AppendLine($"Location: {data.Municipality.Name}");
            sb.AppendLine($"Field: {data.EconomicActivity.Name}");
            sb.AppendLine();
            sb.AppendLine($"Average salary: \t\t{ToSalary(data.AllWorkersSalary.AverageSalaryNetto)}");
            sb.AppendLine($"Average full day salary: \t{ToSalary(data.FullDayWorkersSalary.AverageSalaryNetto)}");
            sb.AppendLine();
            if (data.AllWorkersSalary.Quintile25Netto.HasValue)
                sb.AppendLine($"25% salary: \t\t{ToSalary(data.AllWorkersSalary.Quintile25Netto)}");
            if (data.AllWorkersSalary.Quintile25Netto.HasValue)
                sb.AppendLine($"Median salary: \t\t{ToSalary(data.AllWorkersSalary.MedianNetto)}");
            if (data.AllWorkersSalary.Quintile25Netto.HasValue)
                sb.AppendLine($"75% salary: \t\t{ToSalary(data.AllWorkersSalary.Quintile75Netto)}");
            sb.AppendLine();
            if (data.FullDayWorkersSalary.Quintile25Netto.HasValue)
                sb.AppendLine($"Full day 25% salary: \t\t{ToSalary(data.FullDayWorkersSalary.Quintile25Netto)}");
            if (data.FullDayWorkersSalary.MedianNetto.HasValue)
                sb.AppendLine($"Full day median salary: \t{ToSalary(data.FullDayWorkersSalary.MedianNetto)}");
            if (data.FullDayWorkersSalary.Quintile75Netto.HasValue)
                sb.AppendLine($"Full day 75% salary: \t\t{ToSalary(data.FullDayWorkersSalary.Quintile75Netto)}");
            sb.AppendLine();
            if (data.AllWorkersSalary.AverageSalaryMenNetto.HasValue)
                sb.AppendLine($"Average salary men: \t\t{ToSalary(data.AllWorkersSalary.AverageSalaryMenNetto)}");
            if (data.AllWorkersSalary.AverageSalaryWomenNetto.HasValue)
                sb.AppendLine($"Average salary women: \t\t{ToSalary(data.AllWorkersSalary.AverageSalaryWomenNetto)}");
            if (data.FullDayWorkersSalary.AverageSalaryMenNetto.HasValue)
                sb.AppendLine($"Average full day salary men: \t\t{ToSalary(data.FullDayWorkersSalary.AverageSalaryMenNetto)}");
            if (data.FullDayWorkersSalary.AverageSalaryWomenNetto.HasValue)
                sb.AppendLine($"Average full day salary women: \t{ToSalary(data.FullDayWorkersSalary.AverageSalaryWomenNetto)}");
            sb.Remove(sb.Length - Environment.NewLine.Length, Environment.NewLine.Length);
            return sb.ToString();
        }
        string ToSalary(double? value)
        {
            return value.HasValue ? value.Value.ToString("0.00€") : "null";
        }
    }
}
