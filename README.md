# kozshplxapi

`kozshplxapi` is a .NET client library for the Plex REST API.

It is generated with Kiota and provides strongly typed request builders and models to call Plex endpoints from C# code.

## Compatibility

This package targets:

- `netstandard2.0`
- `netstandard2.1`

## Installation

Install from NuGet:

`dotnet add package Kozshplxapi`

## Basic usage

1. Create an adapter/auth configuration.
2. Create `ApiClient`.
3. Use request builders to call endpoints.

Example:

```csharp
using Kozshplxapi;

// Configure your Kiota request adapter here
// var adapter = ...;

// var client = new ApiClient(adapter);
// var serverStatus = await client.Status.GetAsync();
```

## Development

Build and pack locally:

- `dotnet build Kozshplxapi/Kozshplxapi.csproj -c Release`
- `dotnet pack Kozshplxapi/Kozshplxapi.csproj -c Release -o artifacts`

CI pipeline uses Cake (`ci-pipeline.cs`) and GitHub Actions (`.github/workflows/cake.yml`) to build and publish packages.
