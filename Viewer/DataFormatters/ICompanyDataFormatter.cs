using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Objects;

namespace Viewer.DataFormatters
{
    public interface ICompanyDataFormatter
    {
        string Format(CompanyData data);
    }
}
