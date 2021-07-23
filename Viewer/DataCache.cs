using Viewer.Objects;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Viewer
{
    public class DataCache
    {
        JsonSerializer _serializer = new JsonSerializer();
        public string CacheFilePath { get; private set; }
        public DataCache(string filePath)
        {
            CacheFilePath = filePath;
        }
        public bool IsCached()
        {
            return File.Exists(CacheFilePath);
        }
        public void Cache(CompaniesData data)
        {
            using (StreamWriter file = File.CreateText(CacheFilePath))
            {
                _serializer.Serialize(file, data);
            }
        }
        public CompaniesData Load()
        {
            CompaniesData data;
            using (StreamReader file = File.OpenText(CacheFilePath))
            {
                data = _serializer.Deserialize<CompaniesData>(new JsonTextReader(file));
            }
            return data;
        }
    }
}
