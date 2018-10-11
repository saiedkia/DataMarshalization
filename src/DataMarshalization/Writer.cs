using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataMarshalization
{
    public static class Writer
    {
        public static byte[] Serialize(object @object)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                Type objectType = @object.GetType();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memory, @object);

                return memory.ToArray();
            }
        }

        public static void Save(byte[] data, string path)
        {
            File.WriteAllBytes(path, data);
        }
    }
}
