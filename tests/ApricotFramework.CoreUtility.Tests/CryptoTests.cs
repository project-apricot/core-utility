namespace ApricotFramework.CoreUtility.Tests;

public class CryptoTests
{
    [Theory]
    [InlineData("hello", "LPJNul-wow4m6DsqxbninhsWHlwfp0JecwQzYpOLmCQ=")]
    [InlineData("bar", "_N4rLtula_QIYB-3If6bXDONEO5CnqBPrlURto-_j7k=")]
    [InlineData("héllo-Ω", "VgWYVS00W-elQYBYxInat1CAWGuzurP5Oczo2lnWO6c=")]
    public void ToSafeSha256_ReturnsGoldenValue(string input, string expected)
    {
        Assert.Equal(expected, input.ToSafeSha256());
    }

    [Theory]
    [InlineData("hello", "m3HSJL1i83hdltRq0-o9czGb-8KJDKra4t_3JRlnPKcjI8PZm6XBHXx6zG4UuMXaDEZjR1wuXDre9G9zvN7AQw==")]
    [InlineData("bar", "2CxOtSYcuciqmFXt1n0b0QSC9BUphY2SUJTRc_pmKqkf85vFsYhhUnNIQCHfsW_YKEz2hMzw_Hlb46ovwebBgQ==")]
    [InlineData("héllo-Ω", "M_dkt_NT4aYUR7_GfRpr9FLEMvxNybC-LiQ03iq9BM_2gGIK8ugF6Hc-PPFEe3lE-q4Y9KrMojrFt-RlTowGWw==")]
    public void ToSafeSha512_ReturnsGoldenValue(string input, string expected)
    {
        Assert.Equal(expected, input.ToSafeSha512());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\t\r\n")]
    public void ToSafeSha256_ReturnsEmpty_ForNullOrWhitespace(string? input)
    {
        Assert.Equal(string.Empty, input.ToSafeSha256());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\t\r\n")]
    public void ToSafeSha512_ReturnsEmpty_ForNullOrWhitespace(string? input)
    {
        Assert.Equal(string.Empty, input.ToSafeSha512());
    }

    [Fact]
    public void ToSafeSha256_ContainsNoUrlUnsafeCharacters()
    {
        // 200 varied inputs is enough to hit both substitutions many times over.
        foreach (var input in Enumerable.Range(0, 200).Select(i => $"input-{i}"))
        {
            var hash = input.ToSafeSha256();

            Assert.DoesNotContain('+', hash);
            Assert.DoesNotContain('/', hash);
        }
    }

    [Fact]
    public void ToSafeSha512_ContainsNoUrlUnsafeCharacters()
    {
        foreach (var input in Enumerable.Range(0, 200).Select(i => $"input-{i}"))
        {
            var hash = input.ToSafeSha512();

            Assert.DoesNotContain('+', hash);
            Assert.DoesNotContain('/', hash);
        }
    }

    [Fact]
    public void ToSafeSha256_RetainsBase64Padding()
    {
        // Padding is retained, which is why the output is not strictly base64url.
        // Pinned deliberately: stripping it would change every stored hash.
        Assert.EndsWith("=", "hello".ToSafeSha256(), StringComparison.Ordinal);
        Assert.Equal(44, "hello".ToSafeSha256().Length);
    }

    [Fact]
    public void ToSafeSha512_RetainsBase64Padding()
    {
        Assert.EndsWith("==", "hello".ToSafeSha512(), StringComparison.Ordinal);
        Assert.Equal(88, "hello".ToSafeSha512().Length);
    }

    [Fact]
    public void ToSafeSha256_IsDeterministic()
    {
        Assert.Equal("apricot".ToSafeSha256(), "apricot".ToSafeSha256());
    }

    [Fact]
    public void ToSafeSha256_DiffersFromSha512()
    {
        Assert.NotEqual("hello".ToSafeSha256(), "hello".ToSafeSha512());
    }
}
