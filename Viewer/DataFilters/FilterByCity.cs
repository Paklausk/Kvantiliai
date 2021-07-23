using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Objects;

namespace Viewer.DataFilters
{
    public class FilterByCity : IFilterHandle
    {
        public string City { get; }
        public IList Cities { get; }
        public FilterByCity(string city, IList cities)
        {
            City = city;
            Cities = cities;
        }
        public IEnumerable<CompanyData> Handle(IEnumerable<CompanyData> data)
        {
            if (string.IsNullOrEmpty(City))
                return data;
            if (Cities[Cities.Count - 1].Equals(City))
            {
                string[] filteredCities = new string[Cities.Count - 2];
                for (int i = 0; i < filteredCities.Length; i++)
                    filteredCities[i] = Cities[i + 1].ToString();
                return data.Where(d => d.Municipality != null && !filteredCities.Where(city => d.Municipality.Name.StartsWith(city)).Any());
            }
            return data.Where(d => d.Municipality != null && d.Municipality.Name.StartsWith(City));
        }
    }
}
