using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.Config
{
    public class Configuration
    {
        public class Tax
        {
            public float GPM { get; set; }
            public float PSD { get; set; }
            public float VSD { get; set; }
            public float Pension { get; set; }
            public NPD NPD { get; set; }
        }
        public class NPD
        {
            public float Base { get; set; }
            public float SalaryRatio { get; set; }
            public float SalaryMinusAmount { get; set; }
        }
        public string SalariesFile { get; set; }
        public string EmployeeCountFile { get; set; }
        public string CompaniesInfoFile { get; set; }
        public string CacheFile { get; set; }
        public Tax Taxes { get; set; }
    }
}
