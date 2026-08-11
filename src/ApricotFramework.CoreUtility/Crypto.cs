using System.Security.Cryptography;
using System.Text;

namespace ApricotFramework.CoreUtility;

/// <summary>
/// The set of crypto extensions
/// </summary>
public static class Crypto
{
    /// <summary>
    /// Creates a safe SHA256 hash of the specified input.
    /// </summary>
    /// <remarks>
    /// The result is standard Base64 with the URL-unsafe characters substituted
    /// (<c>+</c> becomes <c>-</c>, <c>/</c> becomes <c>_</c>). Padding is retained,
    /// so this is not strictly base64url. The exact shape is part of the contract:
    /// callers may have persisted these values.
    /// </remarks>
    /// <param name="input">The input.</param>
    /// <returns>A hash, or <see cref="string.Empty"/> when the input is null, empty or whitespace.</returns>
    public static string ToSafeSha256(this string? input)
    {
        // check if empty
        if (string.IsNullOrWhiteSpace(input))
        {
            return string.Empty;
        }

        // compute hash of the UTF-8 bytes
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(input));

        // convert as base64
        return Convert.ToBase64String(hash).Replace("+", "-").Replace("/", "_");
    }

    /// <summary>
    /// Creates a safe SHA512 hash of the specified input.
    /// </summary>
    /// <remarks>
    /// The result is standard Base64 with the URL-unsafe characters substituted
    /// (<c>+</c> becomes <c>-</c>, <c>/</c> becomes <c>_</c>). Padding is retained,
    /// so this is not strictly base64url. The exact shape is part of the contract:
    /// callers may have persisted these values.
    /// </remarks>
    /// <param name="input">The input.</param>
    /// <returns>A hash, or <see cref="string.Empty"/> when the input is null, empty or whitespace.</returns>
    public static string ToSafeSha512(this string? input)
    {
        // check if empty
        if (string.IsNullOrWhiteSpace(input))
        {
            return string.Empty;
        }

        // compute hash of the UTF-8 bytes
        var hash = SHA512.HashData(Encoding.UTF8.GetBytes(input));

        // convert as base64
        return Convert.ToBase64String(hash).Replace("+", "-").Replace("/", "_");
    }
}
