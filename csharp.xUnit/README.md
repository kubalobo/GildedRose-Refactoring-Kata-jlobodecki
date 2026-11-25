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

Run the suite with coverage from this directory using the .NET 10 SDK:

``` cmd
dotnet test GildedRose.sln --collect:"XPlat Code Coverage"
```

In `GildedRoseTests/TestResults/**/coverage.cobertura.xml`, check the
`UpdateQuality` method entry. The characterization suite passes all 20 cases,
including the 30-day approval, and covers 67/67 executable lines and 36/36
branches in the updater.