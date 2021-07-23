using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Objects;

namespace Viewer.DataFilters
{
    public interface IFilterHandle
    {
        IEnumerable<CompanyData> Handle(IEnumerable<CompanyData> data);
    }
}
