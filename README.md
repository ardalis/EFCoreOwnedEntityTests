# EFCoreOwnedEntityTests

A unit test project that tests owned entities in EF Core

The tests currently pass with 2.2.6 but fail with 3.0.0-preview7.19362.6.

Swap out these versions in the csproj file to see the failing behavior in the 3.x version:

```
    <!--<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="3.0.0-preview7.19362.6" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="3.0.0-preview7.19362.6" />-->
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="2.2.6" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="2.2.6" />
```

This is related to [this GitHub issue](https://github.com/aspnet/EntityFrameworkCore/issues/17057), which claims the issue is fixed in a current nightly build as of 9 August 2019.

## Running the Integration Tests

These are [integration tests, not unit tests](https://ardalis.com/unit-test-or-integration-test-and-why-you-should-care). They require a database to work.

- Clone the repo.
- Build it (dotnet build)
- Make sure you have `dotnet ef` installed. [Learn more](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet).
	- `$ dotnet tool install --global dotnet-ef --version 3.0.0-*`
- Run `dotnet ef database update`
- Run the tests `dotnet test`


