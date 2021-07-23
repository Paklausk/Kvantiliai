using System;
using System.Collections.Generic;

namespace Viewer.Objects
{
    public class MunicipalityList : List<Municipality>
    {
        public bool Exists(string municipalityName)
        {
            return Find(municipalityName) != null;
        }
        public Municipality Find(string municipalityName)
        {
            foreach (var municipality in this)
                if (municipalityName.Equals(municipality.Name))
                    return municipality;
            return null;
        }
        public Municipality Append(string municipalityName)
        {
            Municipality municipality = new Municipality();
            municipality.Name = municipalityName;
            Add(municipality);
            return municipality;
        }
    }
}
