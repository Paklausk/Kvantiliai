using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Objects;

namespace Viewer.Calculators
{
    public class MedianCalculator
    {
        class MediaItem
        {
            public double Salary { get; set; }
            public long Count { get; set; }
            public MediaItem(double salary, long count)
            {
                Salary = salary;
                Count = count;
            }
        }
        class MedianLister : List<MediaItem>
        {
            public double GetMedian()
            {
                long allCount = GetAllCount();
                double salary = this.Sum((m) => m.Salary * m.Count / allCount);
                return salary;
            }
            public long GetAllCount()
            {
                return this.Sum((m) => m.Count);
            }
        }
        public double CalculateMedian(IEnumerable<CompanyData> companiesList, Func<CompanyData, double?> selector)
        {
            MedianLister medianList = new MedianLister();
            foreach (var item in companiesList)
            {
                double? selected = selector(item);
                if (selected.HasValue && item.EmployeeCount.HasValue)
                    medianList.Add(new MediaItem(selected.Value, item.EmployeeCount.Value));
            }
            return medianList.GetMedian();
        }
    }
}
