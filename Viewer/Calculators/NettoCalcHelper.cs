using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Config;

namespace Viewer.Calculators
{
    public static class NettoCalcHelper
    {
        static Configuration.Tax Taxes;
        public static void SetTaxes(Configuration.Tax taxes)
        {
            Taxes = taxes;
        }
        public static double? CalculateNettoSalary(double? bruttoSalary)
        {
            if (!bruttoSalary.HasValue)
                return null;
            var npd = Math.Max(Math.Round(Taxes.NPD.Base - Taxes.NPD.SalaryRatio * (bruttoSalary.Value - Taxes.NPD.SalaryMinusAmount), 2), 0);
            var netto = bruttoSalary - Math.Round((bruttoSalary.Value - npd) * Taxes.GPM, 2) - Math.Round(bruttoSalary.Value * (Taxes.Pension + Taxes.PSD + Taxes.VSD), 2);
            return netto;
        }
    }
}
