using Downloader.Objects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Downloader
{
    class Program
    {
        const string SALARIES_CSV_FILE_NAME = "VIDURKIAI.CSV", EMPLOYEE_COUNT_FILE_NAME = "APDRAUSTUJU_SKAICIUS.CSV";
        const char SALARIES_CSV_SEPARATOR = ';';
        const int SALARIES_DATE_LINE_INDEX = 4;
        const string DATA_FILES_DIR_NAME = "DataFiles", CONFIGS_DIR_NAME = "Configs", CACHE_DIR_NAME = "Cache";
        static readonly string FILES_PATH = $"{AppContext.BaseDirectory}{DATA_FILES_DIR_NAME}\\", CONFIGS_PATH = $"{AppContext.BaseDirectory}{CONFIGS_DIR_NAME}\\";
        static void Main(string[] args)
        {
            Directory.CreateDirectory(FILES_PATH);
            Directory.CreateDirectory(CONFIGS_PATH);
            Directory.CreateDirectory($"{AppContext.BaseDirectory}{CACHE_DIR_NAME}\\");

            DateTime salariesDate;
            string salariesSaveFileName, employeeCountSaveFileName, companiesInfoSaveFileName = null;
            WebClient client = new WebClient();

            #region SaveSalariesFile
            using (var zipStream = new MemoryStream(client.DownloadData("http://sodra.is.lt/Failai/Vidurkiai.zip")))
            {
                ZipArchive zipArchive = new ZipArchive(zipStream);
                var zipSalariesEntry = zipArchive.GetEntry(SALARIES_CSV_FILE_NAME);
                salariesDate = GetSalariesDate(zipSalariesEntry);
                salariesSaveFileName = GetSaveFileName(Path.GetFileNameWithoutExtension(SALARIES_CSV_FILE_NAME), Path.GetExtension(SALARIES_CSV_FILE_NAME), salariesDate);
                var fullSalariesSavePath = FILES_PATH + salariesSaveFileName;

                if (File.Exists(fullSalariesSavePath))
                {
                    Console.Write("Detected that files were already downloaded, type 'yes' to overwrite: ");
                    if (!Console.ReadLine().ToLowerInvariant().Equals("yes"))
                        return;
                }

                using (var salariesCSV = new StreamReader(zipSalariesEntry.Open()))
                    using (var saveFileStream = File.OpenWrite(fullSalariesSavePath))
                        salariesCSV.BaseStream.CopyTo(saveFileStream);
            }
            #endregion
            #region SaveEmployeeCountFile
            using (var zipStream = new MemoryStream(client.DownloadData("http://sodra.is.lt/Failai/Apdraustuju_skaicius.zip")))
            {
                ZipArchive zipArchive = new ZipArchive(zipStream);
                using (var employeeCountCSV = new StreamReader(zipArchive.GetEntry(EMPLOYEE_COUNT_FILE_NAME).Open()))
                {
                    employeeCountSaveFileName = GetSaveFileName(Path.GetFileNameWithoutExtension(EMPLOYEE_COUNT_FILE_NAME), Path.GetExtension(EMPLOYEE_COUNT_FILE_NAME), salariesDate);
                    using (var saveFileStream = File.OpenWrite(FILES_PATH + employeeCountSaveFileName))
                    {
                        employeeCountCSV.BaseStream.CopyTo(saveFileStream);
                    }
                }
            }
            #endregion
            #region SaveCompaniesInfoFile
            for (int i = 0; i < 3; i++)
            {
                DateTime companiesInfoDate = salariesDate.AddMonths(-i);
                try
                {
                    string url = $"https://atvira.sodra.lt/imones/downloads/{companiesInfoDate.Year}/daily-{companiesInfoDate.Year}-{companiesInfoDate.Month.ToString("00")}.csv.zip";
                    using (var zipStream = new MemoryStream(client.DownloadData(url)))
                    {
                        ZipArchive zipArchive = new ZipArchive(zipStream);
                        var companiesInfoZipEntry = zipArchive.Entries[0];
                        using (var companiesInfoCSV = new StreamReader(companiesInfoZipEntry.Open()))
                        {
                            companiesInfoSaveFileName = companiesInfoZipEntry.Name;
                            using (var saveFileStream = File.OpenWrite(FILES_PATH + companiesInfoSaveFileName))
                            {
                                companiesInfoCSV.BaseStream.CopyTo(saveFileStream);
                                break;
                            }
                        }
                    }
                }
                catch (WebException) { }
            }
            #endregion
            #region WriteConfig
            JObject json = new JObject();
            json["salariesFile"] = $"{DATA_FILES_DIR_NAME}\\{salariesSaveFileName}";
            json["employeeCountFile"] = $"{DATA_FILES_DIR_NAME}\\{employeeCountSaveFileName}";
            json["companiesInfoFile"] = $"{DATA_FILES_DIR_NAME}\\{companiesInfoSaveFileName}";
            json["cacheFile"] = $"{CACHE_DIR_NAME}\\{GetSaveFileName("cache", ".json", salariesDate)}";

            JObject taxes = new JObject();
            taxes["GPM"] = 0.2;
            taxes["PSD"] = 0.0698;
            taxes["VSD"] = 0.1252;
            taxes["NPD"] = JObject.FromObject(new { @base = 400, salaryRatio = 0.18, salaryMinusAmount = 642 });
            taxes["pension"] = 0.03;
            json["taxes"] = taxes;

            string configFileName = GetSaveFileName("config", ".json", salariesDate);
            File.WriteAllText($"{CONFIGS_PATH}{configFileName}", json.ToString());
            #endregion
            #region CreateLink
            string shortcutFullPath = $"{AppContext.BaseDirectory}{GetSaveFileName("Salary_Viewer", ".lnk", salariesDate)}";
            ShortcutHelper.Create(
                shortcutFullPath,
                $"{AppContext.BaseDirectory}Viewer.exe",
                $"{CONFIGS_DIR_NAME}\\{configFileName}",
                AppContext.BaseDirectory,
                $"Open salary viewer for month {salariesDate.Year}.{salariesDate.Month}",
                string.Empty,
                $"{AppContext.BaseDirectory}Viewer.exe"
                );
            #endregion
            #region Start salary viewer
            Console.WriteLine("Download finished. If you want to start salary viewer type 'y' or 'yes': ");
            var readLineResult = Console.ReadLine().ToLowerInvariant();
            if (readLineResult.Equals("y") || readLineResult.Equals("yes"))
            {
                Process proc = new Process();
                proc.StartInfo.FileName = shortcutFullPath;
                proc.Start();
            }
            #endregion
        }
        static DateTime GetSalariesDate(ZipArchiveEntry zipSalariesEntry)
        {
            using (var salariesCSV = new StreamReader(zipSalariesEntry.Open()))
            {
                string salariesDateLine = string.Empty;
                for (int i = 0; i < SALARIES_DATE_LINE_INDEX; i++)
                    salariesDateLine = salariesCSV.ReadLine();
                string salariesDateText = salariesDateLine.Split(SALARIES_CSV_SEPARATOR)[2];
                return GetSalariesDate(salariesDateText);
            }
            throw new Exception("Failed to extract date of salaries");
        }
        static DateTime GetSalariesDate(string salariesDateText)
        {
            var yearMatch = new Regex(@"\d\d\d\d").Match(salariesDateText);
            int year = int.Parse(yearMatch.Value);
            int month = int.Parse(new Regex(@"\d\d").Match(salariesDateText.Substring(yearMatch.Index + 4)).Value);
            return new DateTime(year, month, 1);
        }
        static string GetSaveFileName(string baseFileName, string extension, DateTime dataDate)
        {
            var modifiedDate = dataDate.AddMonths(1);
            return $"{baseFileName}_{modifiedDate.Year}_{modifiedDate.Month}{extension}";
        }
    }
}
