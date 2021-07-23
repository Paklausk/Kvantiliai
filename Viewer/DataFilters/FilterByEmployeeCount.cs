using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Objects;

namespace Viewer.DataFilters
{
    public class FilterByEmployeeCount : IFilterHandle
    {
        public int MinEmployeeCount { get; }
        public int? MaxEmployeeCount { get; }
        public FilterByEmployeeCount(int minEmployeeCount, int? maxEmployeeCount)
        {
            MinEmployeeCount = minEmployeeCount;
            MaxEmployeeCount = maxEmployeeCount;
        }
        public IEnumerable<CompanyData> Handle(IEnumerable<CompanyData> data)
        {
            if (MinEmployeeCount == 0 && !MaxEmployeeCount.HasValue)
                return data;
            return data.Where(d => d.EmployeeCount >= MinEmployeeCount && (!MaxEmployeeCount.HasValue || d.EmployeeCount <= MaxEmployeeCount));
        }
    }
}
