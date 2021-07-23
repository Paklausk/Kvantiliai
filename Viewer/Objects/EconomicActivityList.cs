using System;
using System.Collections.Generic;

namespace Viewer.Objects
{
    public class EconomicActivityList : List<EconomicActivity>
    {
        public bool Exists(long economicActivityCode, string economicActivityName)
        {
            return Find(economicActivityCode, economicActivityName) != null;
        }
        public EconomicActivity Find(long economicActivityCode, string economicActivityName)
        {
            foreach (var economicActivity in this)
                if (economicActivity.Code == economicActivityCode && economicActivity.Name.Equals(economicActivityName))
                    return economicActivity;
            return null;
        }
        public EconomicActivity Append(long economicActivityCode, string economicActivityName)
        {
            EconomicActivity economicActivity = new EconomicActivity();
            economicActivity.Code = economicActivityCode;
            economicActivity.Name = economicActivityName;
            Add(economicActivity);
            return economicActivity;
        }
    }
}
