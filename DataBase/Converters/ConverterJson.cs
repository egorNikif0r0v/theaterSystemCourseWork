using System.IO;
using Newtonsoft.Json;

namespace DataBase.Converters
{
    public class ConverterJson : IConverter
    {
        void IConverter.Load<T>(string fileName, T obj)
        {
            using (StreamWriter file = File.CreateText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, obj);
            }
        }

        T IConverter.Unload<T>(string fileName)
        {
            using (StreamReader file = File.OpenText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (T)serializer.Deserialize(file, typeof(T));
            }
        }

        public void Load<T>(string fileName, T obj)
        {
            using (StreamWriter file = File.CreateText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, obj);
            }
        }

        public T Unload<T>(string fileName)
        {
            using (StreamReader file = File.OpenText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (T)serializer.Deserialize(file, typeof(T));
            }
        }

        /*

       using System.Text.Json;
       static private JsonSerializerOptions _options = new JsonSerializerOptions
       {
           WriteIndented = true
       };

       async static public Task<T> Deserialization<T>(string fileName)
       {
           using (var fs = new FileStream(fileName, FileMode.Open))
           {
               var obj = await JsonSerializer.DeserializeAsync<T>(fs);
               return obj;
           }
       }
       */
    }
}

