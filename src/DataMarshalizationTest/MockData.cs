using System;

namespace DataMarshalizationTest
{
    [Serializable]
    public class MockData
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public int Age { get; set; }

        public SimpleObject SimpleObject { get; set; }
    }

    [Serializable]
    public class SimpleObject
    {
        public string SomeValue { get; set; }
    }
}
