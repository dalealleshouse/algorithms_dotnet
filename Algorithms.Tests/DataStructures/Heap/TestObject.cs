namespace Algorithms.Tests.DataStructures.Heap;

public class TestObject
{
    public TestObject(int value)
    {
        this.Value = value;
    }

    public int Value { get; set; }

    public static int MaxPriorityFunc(TestObject x, TestObject y)
    {
        return x.Value - y.Value;
    }

    public override string ToString()
    {
        return this.Value.ToString();
    }
}
