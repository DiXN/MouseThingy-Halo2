using System.Runtime.Serialization.Json;
using System.Text;
using System.IO;

namespace MouseThingy
{
    public class JsonHelper<T> where T : class
    {
        public string Serialize(T obj)
        {
            DataContractJsonSerializer serializer = 
                  new DataContractJsonSerializer(obj.GetType());

            using( MemoryStream ms = new MemoryStream()) 
            {
                serializer.WriteObject(ms, obj);
                return Encoding.Default.GetString(ms.ToArray());
            }
        }

        public T Deserialize(string json)
        {
            using( MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer =
                      new DataContractJsonSerializer(typeof(T));

                return (T)serializer.ReadObject(ms);
            }
        }

        public void OutputJsonToFile(string json)
        {
            File.WriteAllText("settings.json", json);
        }

        public string ReadJsonFile()
        {
            return File.ReadAllText("settings.json");
        }
    }
}
