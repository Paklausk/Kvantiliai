# Kvantiliai
[![GitHub](https://img.shields.io/github/license/Paklausk/Kvantiliai?style=for-the-badge)](https://github.com/Paklausk/Kvantiliai/blob/master/LICENSE)
[![GitHub last commit](https://img.shields.io/github/last-commit/Paklausk/Kvantiliai.svg?style=for-the-badge)]()
## Lithuanian government companies and salary data downloader and viewer

Software consists of two parts **downloader** application which downloads and saves all most recent months salary and company data files if it haven't already and creates launch shortcut for that month, so one may can have data for multiple months. Second part of the software is **viewer** application, which should always be started from shortcut which was created by **downloader** application. First time **viewer** processes new data it caches it for faster load times in the future. **Viewer** allows to filter data by companies name, employees count, average salary. Company list is ordered by average salary and all salaries are presented after taxes based on Lithuanian laws with 3% pension fund contribution. **Viewer** also presents basic statistics of filtered companies like total number companies, total number of employees and general salary calculations.

## Viewer UI screenshot

![Screenshot](.docs/ViewerUI.png)
