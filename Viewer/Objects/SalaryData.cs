using System;
using Viewer.Calculators;

namespace Viewer.Objects
{
    public class SalaryData
    {
        public double? AverageSalaryNetto { get { return NettoCalcHelper.CalculateNettoSalary(AverageSalary); } }
        public double? AverageSalaryWomenNetto { get { return NettoCalcHelper.CalculateNettoSalary(AverageSalaryWomen); } }
        public double? AverageSalaryMenNetto { get { return NettoCalcHelper.CalculateNettoSalary(AverageSalaryMen); } }
        public double? Quintile25Netto { get { return NettoCalcHelper.CalculateNettoSalary(Quintile25); } }
        public double? MedianNetto { get { return NettoCalcHelper.CalculateNettoSalary(Median); } }
        public double? Quintile75Netto { get { return NettoCalcHelper.CalculateNettoSalary(Quintile75); } }
        public double? StandardDeviationNetto { get { return NettoCalcHelper.CalculateNettoSalary(StandardDeviation); } }
        public double? AverageSalary { get; set; }
        public double? AverageSalaryWomen { get; set; }
        public double? AverageSalaryMen { get; set; }
        public double? Quintile25 { get; set; }
        public double? Median { get; set; }
        public double? Quintile75 { get; set; }
        public double? StandardDeviation { get; set; }
    }
}
