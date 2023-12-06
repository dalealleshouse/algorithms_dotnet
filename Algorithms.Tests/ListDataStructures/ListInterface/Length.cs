namespace Algorithms.Tests.ListDataStructures.ListInterface;

using Xunit;

public class Length : ListTests
{
    [Fact]
    public void IncrementsLengthForEachInsert()
    {
        this.RunTestOnAllLists<int>(sut =>
        {
            for (int i = 1; i < 10; i++)
            {
                sut.Insert(i * 2);
                Assert.Equal(i, sut.Length);
            }
        });
    }

    [Fact(Skip = "Not implemented")]
    public void DecrementsLengthForEachDelete()
    {
        this.RunTestOnAllLists<int>(
            sut =>
            {
                for (int i = 0; i < 10; i++)
                {
                    sut.Delete(i);
                    Assert.Equal(10 - i, sut.Length);
                }
            },
            SutFactory.BuildArray(10));
    }
}
