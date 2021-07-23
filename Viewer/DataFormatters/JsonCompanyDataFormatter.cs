using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewer.Objects;

namespace Viewer.DataFormatters
{
    public class JsonCompanyDataFormatter : ICompanyDataFormatter
    {
        class DoubleJsonConverter : JsonConverter<double?>
        {
            public override double? ReadJson(JsonReader reader, Type objectType, double? existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                double? readedValue = reader.ReadAsDouble();
                return readedValue ?? existingValue;
            }
            public override void WriteJson(JsonWriter writer, double? value, JsonSerializer serializer)
            {
                writer.WriteValue(value.HasValue ? value.Value.ToString("0.##") : "null");
            }
        }
        JsonSerializerSettings _jsonSettings = new JsonSerializerSettings();
        public JsonCompanyDataFormatter()
        {
            _jsonSettings.Formatting = Formatting.Indented;
            _jsonSettings.Converters.Add(new DoubleJsonConverter());
        }
        public string Format(CompanyData data)
        {
            string json = JsonConvert.SerializeObject(data, _jsonSettings);
            return json;
        }
    }
}
