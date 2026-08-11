namespace ApricotFramework.CoreUtility.Tests;

public class RndTests
{
    private const string ExpectedCharset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

    [Theory]
    [InlineData(1)]
    [InlineData(8)]
    [InlineData(32)]
    [InlineData(256)]
    public void GetString_ReturnsRequestedLength(int size)
    {
        Assert.Equal(size, Rnd.GetString(size).Length);
    }

    [Fact]
    public void GetString_UsesOnlyAlphanumericCharacters()
    {
        var generated = Rnd.GetString(4096);

        Assert.All(generated, c => Assert.Contains(c, ExpectedCharset));
    }

    [Fact]
    public void GetString_ReturnsEmpty_ForZeroSize()
    {
        Assert.Equal(string.Empty, Rnd.GetString(0));
    }

    [Fact]
    public void GetString_Throws_ForNegativeSize()
    {
        Assert.Throws<OverflowException>(() => Rnd.GetString(-1));
    }

    [Fact]
    public void GetString_ProducesDistinctValues()
    {
        // 100 draws from a 62^16 space colliding would mean the generator is broken.
        var values = Enumerable.Range(0, 100).Select(_ => Rnd.GetString(16)).ToList();

        Assert.Equal(values.Count, values.Distinct().Count());
    }

    [Fact]
    public void GetString_CoversTheWholeCharset()
    {
        var generated = Rnd.GetString(20_000);

        Assert.Equal(ExpectedCharset.Length, generated.Distinct().Count());
    }
}
