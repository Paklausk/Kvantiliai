using Viewer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Viewer.Config;
using Viewer.Calculators;

namespace Viewer
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 0)
                return;
            var json = File.ReadAllText(ToFullPath(args[0]));
            var config = JsonConvert.DeserializeObject<Configuration>(json);
            NettoCalcHelper.SetTaxes(config.Taxes);
            CompaniesData data = null;
            DataCache cache = new DataCache(config.CacheFile);
            if (cache.IsCached())
                data = cache.Load();
            else
            {
                data = new DataLoader().Load(ToFullPath(config.SalariesFile), ToFullPath(config.EmployeeCountFile), ToFullPath(config.CompaniesInfoFile));
                cache.Cache(data);
            }
            Form form = new MainWindow(data);
            if (args.Length > 0)
                form.Text = args[0];
            Application.Run(form);
        }
        static string ToFullPath(string relativePath)
        {
            return $"{AppContext.BaseDirectory}{relativePath}";
        }
    }
}
