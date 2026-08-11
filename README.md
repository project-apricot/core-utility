# ApricotFramework.CoreUtility

[![NuGet](https://img.shields.io/nuget/v/ApricotFramework.CoreUtility.svg)](https://www.nuget.org/packages/ApricotFramework.CoreUtility/)
[![CI](https://github.com/project-apricot/core-utility/actions/workflows/ci.yml/badge.svg)](https://github.com/project-apricot/core-utility/actions/workflows/ci.yml)
[![License](https://img.shields.io/badge/license-Apache--2.0-blue.svg)](https://github.com/project-apricot/core-utility/blob/main/LICENSE)

Zero-dependency utilities extending the .NET base class library: URL-safe hashing,
cryptographically strong random strings, and URL helpers.

## Install

```bash
dotnet add package ApricotFramework.CoreUtility
```


## Usage

```csharp
using ApricotFramework.CoreUtility;

var hash  = "hello".ToSafeSha256();
var token = Rnd.GetString(32);
var url   = UrlExt.EnsureSlash("https://example.com/api");
```

Note that the hash output is URL-safe Base64 that **retains padding**, so it is not
strictly `base64url`. That shape is a compatibility contract and will not change without a
major version.
