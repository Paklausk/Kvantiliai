using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Viewer.DataFormatters;
using Viewer.DataFilters;
using Viewer.Objects;
using System.Diagnostics;
using Viewer.Calculators;
using System.Threading.Tasks;

namespace Viewer
{
    public partial class MainWindow : Form
    {
        CompaniesData _data;
        AsyncFilter _filter = new AsyncFilter();
        ICompanyDataFormatter _companyDataFormatter = new TextCompanyDataFormatter();
        public MainWindow(CompaniesData data)
        {
            InitializeComponent();
            _filter.OnFilteringFinished += OnFilteringFinished;
            _data = data;
            List<int> nullIdx = new List<int>(100);
            for (int i = 0; i < data.Count; i++)
                if (data[i] == null)
                {
                    nullIdx.Add(i);
                }
        }

        private void OnFilteringFinished(IEnumerable<CompanyData> filteredData)
        {
            var finalData = filteredData.OrderByDescending((d) => d.AllWorkersSalary.AverageSalaryNetto);
            var medianCalculator = new MedianCalculator();
            var dataCount = finalData.Count();
            long employeesCount = 0;
            double averageSalary = 0, median25Salary = 0, medianSalary = 0, median75Salary = 0, average75Salary = 0, median75Salary2 = 0;
            var m75Array = finalData.Where(d => d.FullDayWorkersSalary.Quintile75Netto.HasValue).ToArray();
            Parallel.Invoke(
                () => employeesCount = finalData.Sum(d => d.EmployeeCount.GetValueOrDefault(0)),
                () => averageSalary = finalData.Sum((d) => d.AllWorkersSalary.AverageSalaryNetto).GetValueOrDefault(0) / dataCount,
                () => median25Salary = medianCalculator.CalculateMedian(finalData, (d) => d.AllWorkersSalary.Quintile25Netto),
                () => medianSalary = medianCalculator.CalculateMedian(finalData, (d) => d.AllWorkersSalary.MedianNetto),
                () => median75Salary = medianCalculator.CalculateMedian(finalData, (d) => d.AllWorkersSalary.Quintile75Netto),
                () => average75Salary = m75Array.Sum((d) => d.FullDayWorkersSalary.Quintile75Netto).GetValueOrDefault(0) / m75Array.Length,
                () => median75Salary2 = m75Array.Length > 0 ? m75Array.OrderBy((d) => d.FullDayWorkersSalary.Quintile75Netto).ToArray()[m75Array.Length / 2].FullDayWorkersSalary.Quintile75Netto.GetValueOrDefault(0) : 0
            );

            BeginInvoke(new MethodInvoker(() => {
                companiesListBox.BeginUpdate();
                companiesListBox.Items.Clear();
                companiesListBox.Items.AddRange(finalData.ToArray());
                if (dataCount == 1)
                    companiesListBox.SelectedIndex = 0;
                companiesListBox.EndUpdate();
                companyInfoBox.Text = "";
                companiesLabel.Text = dataCount.ToString();
                employeesLabel.Text = employeesCount.ToString();
                avgSalaryLabel.Text = SalaryFormatter(averageSalary);
                m25SalaryLabel.Text = SalaryFormatter(median25Salary);
                medianSalaryLabel.Text = SalaryFormatter(medianSalary);
                m75SalaryLabel.Text = SalaryFormatter(median75Salary);
                avg75SalaryLabel.Text = SalaryFormatter(average75Salary);
                m75Salaryv2Label.Text = SalaryFormatter(median75Salary2);
            }));
        }
        private string SalaryFormatter(double salary)
        {
            return salary.ToString("0.00€");
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (filterTextBox.Text.Length > 1)
            {
                _filter.SetFilterHandle(new FilterByText(filterTextBox.Text));
            }
            else _filter.RemoveFilterHandle<FilterByText>();
            _filter.StartTask(_data);
        }
        private void itCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (itCheckBox.Checked)
            {
                _filter.SetFilterHandle(new FilterByIT());
            }
            else _filter.RemoveFilterHandle<FilterByIT>();
            _filter.StartTask(_data);
        }
        private void minEmployeesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _filter.SetFilterHandle(new FilterByEmployeeCount(Convert.ToInt32(minEmployeesBox.SelectedItem), null));
            _filter.StartTask(_data);
        }
        private void minAvgSalaryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _filter.SetFilterHandle(new FilterByAverageNettoSalary(Convert.ToInt32(minAvgSalaryBox.SelectedItem)));
            _filter.StartTask(_data);
        }
        private void cityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _filter.SetFilterHandle(new FilterByCity(cityBox.Text, cityBox.Items));
            _filter.StartTask(_data);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (companiesListBox.SelectedItem != null)
            {
                companyInfoBox.Text = _companyDataFormatter.Format(companiesListBox.SelectedItem as CompanyData);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _filter.Dispose();
        }
    }
}
