# Gilded Rose starting position in C# xUnit

## Build the project

Use your normal build tools to build the projects in Debug mode.
For example, you can use the `dotnet` command line tool:

``` cmd
dotnet build GildedRose.sln -c Debug
```

## Run the Gilded Rose Command-Line program

For e.g. 10 days:

``` cmd
GildedRose/bin/Debug/net10.0/GildedRose 10
```

## Run all the unit tests

``` cmd
dotnet test
```

## Inventory characterization tests

The starter suite had two failures: `GildedRoseTest.foo` expected the placeholder
name `fixme` instead of `foo`, and `ApprovalTest.Foo` had no verified file.
`ApprovalTest.ThirtyDays` passed against the existing snapshot.

GitHub Actions runs the full suite on pull requests and pushes to `main`.
It requires 100% line and branch coverage for the `GildedRose` class, including
private updater helpers, and uploads `coverage.cobertura.xml` as the
`updater-coverage` artifact even if the coverage check fails.

To run the same check from the repository root with the .NET 10 SDK and Python 3:

```sh
results=$(mktemp -d)
dotnet test csharp.xUnit/GildedRose.sln --collect:"XPlat Code Coverage" \
  --settings csharp.xUnit/updater-coverage.runsettings --results-directory "$results" &&
  python3 csharp.xUnit/check-updater-coverage.py "$results"/*/coverage.cobertura.xml
```