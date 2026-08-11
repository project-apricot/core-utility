namespace ApricotFramework.CoreUtility;

/// <summary>
/// The URL additions
/// </summary>
public static class UrlExt
{
    /// <summary>
    /// Ensures the trailing slash to the url
    /// </summary>
    /// <param name="url">The url</param>
    /// <returns>The url, guaranteed to end with a single trailing slash.</returns>
    /// <exception cref="NullReferenceException">Thrown when <paramref name="url"/> is null.</exception>
    public static string EnsureSlash(string url)
    {
        return url.EndsWith('/') ? url : $"{url}/";
    }
}
