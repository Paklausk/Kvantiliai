using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Objects;

namespace Viewer.DataFilters
{
    public class FilterByAverageNettoSalary : IFilterHandle
    {
        public double MinSalary { get; }
        public FilterByAverageNettoSalary(double minSalary)
        {
            MinSalary = minSalary;
        }
        public IEnumerable<CompanyData> Handle(IEnumerable<CompanyData> data)
        {
            if (MinSalary == 0)
                return data;
            return data.Where(d => d.AllWorkersSalary != null && d.AllWorkersSalary.AverageSalaryNetto >= MinSalary);
        }
    }
}
