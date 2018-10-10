using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataMarshalization
{
    public static class Reader
    {
        public static T Read<T>(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            return Read<T>(bytes);
        }

        public static T Read<T>(byte[] data)
        {
            using (MemoryStream memory = new MemoryStream())
            {

                BinaryFormatter formatter = new BinaryFormatter();
                memory.Write(data, 0, data.Length);
                memory.Seek(0, SeekOrigin.Begin);
                object x = formatter.Deserialize(memory);
                return (T)formatter.Deserialize(memory);
            }
        }
    }
}
