using System;

namespace Viewer.Objects
{
    public class EconomicActivityManager
    {
        public EconomicActivityList Convert(CompanyInfoLine[] companyInfos)
        {
            EconomicActivityList list = new EconomicActivityList();
            foreach (var companyInfo in companyInfos)
                if (companyInfo.EconomicActivityCode.HasValue)
                {
                    if (!list.Exists(companyInfo.EconomicActivityCode.Value, companyInfo.EconomicActivityName))
                        companyInfo.EconomicActivity = list.Append(companyInfo.EconomicActivityCode.Value, companyInfo.EconomicActivityName);
                    else companyInfo.EconomicActivity = list.Find(companyInfo.EconomicActivityCode.Value, companyInfo.EconomicActivityName);
                }
            return list;
        }
    }
}
