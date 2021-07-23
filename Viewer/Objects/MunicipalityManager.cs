using System;

namespace Viewer.Objects
{
    public class MunicipalityManager
    {
        public MunicipalityList Convert(CompanyInfoLine[] companyInfos)
        {
            MunicipalityList list = new MunicipalityList();
            foreach (var companyInfo in companyInfos)
            {
                if (!list.Exists(companyInfo.MunicipalityName))
                    companyInfo.Municipality = list.Append(companyInfo.MunicipalityName);
                else companyInfo.Municipality = list.Find(companyInfo.MunicipalityName);
            }
            return list;
        }
    }
}
