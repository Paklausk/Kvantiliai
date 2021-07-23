using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Objects;

namespace Viewer.DataFilters
{
    public class FilterByText : IFilterHandle
    {
        public string Text { get; }
        public FilterByText(string text)
        {
            Text = text;
        }
        public IEnumerable<CompanyData> Handle(IEnumerable<CompanyData> data)
        {
            return data.Where(d => d.ToString().ToLowerInvariant().Contains(Text.ToLowerInvariant()));
        }
    }
}
