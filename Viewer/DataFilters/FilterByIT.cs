using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Objects;

namespace Viewer.DataFilters
{
    public class FilterByIT : IFilterHandle
    {
        public IEnumerable<CompanyData> Handle(IEnumerable<CompanyData> data)
        {
            return data.Where(d => d.EconomicActivity != null && (d.EconomicActivity.Code == 620000 || d.EconomicActivity.Code == 620100 || d.EconomicActivity.Code == 620200 || d.EconomicActivity.Code == 620900 || d.EconomicActivity.Code == 262000 || d.EconomicActivity.Code == 582100 || d.EconomicActivity.Code == 582000 || d.EconomicActivity.Code == 582900));
        }
    }
}
