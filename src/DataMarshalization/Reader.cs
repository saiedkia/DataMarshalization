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
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream memory = new MemoryStream())
            {
                memory.Write(data, 0, data.Length);
                memory.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(memory);
            }
        }
    }
}
