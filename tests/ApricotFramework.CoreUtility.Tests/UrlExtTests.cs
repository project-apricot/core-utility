namespace ApricotFramework.CoreUtility.Tests;

public class UrlExtTests
{
    [Theory]
    [InlineData("https://example.com", "https://example.com/")]
    [InlineData("https://example.com/", "https://example.com/")]
    [InlineData("https://example.com/api", "https://example.com/api/")]
    [InlineData("https://example.com/api/", "https://example.com/api/")]
    [InlineData("", "/")]
    [InlineData("/", "/")]
    public void EnsureSlash_AppendsTrailingSlashWhenMissing(string url, string expected)
    {
        Assert.Equal(expected, UrlExt.EnsureSlash(url));
    }

    [Fact]
    public void EnsureSlash_IsIdempotent()
    {
        var once = UrlExt.EnsureSlash("https://example.com");

        Assert.Equal(once, UrlExt.EnsureSlash(once));
    }

    [Fact]
    public void EnsureSlash_Throws_ForNull()
    {
        Assert.Throws<NullReferenceException>(() => UrlExt.EnsureSlash(null!));
    }
}
