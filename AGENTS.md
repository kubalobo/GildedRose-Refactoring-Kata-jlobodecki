# Gilded Rose Kata

- Work in [`csharp.xUnit/`](csharp.xUnit/). Read the [Gilded Rose requirements](GildedRoseRequirements.md) before changing behavior.
- From the repository root, run `dotnet test csharp.xUnit/GildedRose.sln` with the .NET 10 SDK. The starter includes a deliberately failing `foo` unit test and a `Foo` approval example without a verified file.
- Preserve the `Item` class and the `Items` member. `UpdateQuality` must update the existing `Item` instances in place, without replacing the list or its entries.
- A pure refactor must not change the 30-day output or its [verified snapshot](csharp.xUnit/GildedRoseTests/ApprovalTest.ThirtyDays.verified.txt). If `ApprovalTest.ThirtyDays` fails during a refactor, fix the refactor rather than re-approving the output.
