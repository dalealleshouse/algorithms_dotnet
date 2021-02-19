namespace Algorithms.Tests.DataStructures.Heap
{
    public partial class Reprioritize
    {
        public class TestObject
        {
            static public int MaxPriorityFunc(TestObject x, TestObject y)
            {
                return x.Value - y.Value;
            }

            public TestObject(int value)
            {
                Value = value;
            }

            public int Value { get; set; }
        }
    }
}
