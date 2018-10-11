using DataMarshalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataMarshalizationTest
{
    [TestClass]
    public class DMTest
    {
        [TestMethod]
        public void In_memory_serialization()
        {
            MockData data = new MockData()
            {
                Age = 12,
                Family = "fam",
                Name = "name",
                SimpleObject = new SimpleObject()
                {
                    SomeValue = "some value"
                }
            };

            byte[] byteData = Writer.Serialize(data);

            MockData deserializedData = Reader.Read<MockData>(byteData);

            Assert.AreEqual(data.Age, deserializedData.Age);
            Assert.AreEqual(data.Name, deserializedData.Name);
            Assert.AreEqual(data.SimpleObject.SomeValue, deserializedData.SimpleObject.SomeValue);
        }


        [TestMethod]
        public void File_RW_Serialization()
        {
            MockData data = new MockData()
            {
                Age = 12,
                Family = "fam",
                Name = "name",
                SimpleObject = new SimpleObject()
                {
                    SomeValue = "some value"
                }
            };

            Writer.Save(Writer.Serialize(data), AppDomain.CurrentDomain.BaseDirectory + "\\data.bin");
            MockData deserializedData = Reader.Read<MockData>(AppDomain.CurrentDomain.BaseDirectory + "\\data.bin");


            Assert.AreEqual(data.Age, deserializedData.Age);
            Assert.AreEqual(data.Name, deserializedData.Name);
            Assert.AreEqual(data.SimpleObject.SomeValue, deserializedData.SimpleObject.SomeValue);
        }
    }
}
