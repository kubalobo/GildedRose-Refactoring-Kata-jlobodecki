_Support this and all my katas via [Patreon](https://www.patreon.com/EmilyBache)_

# Gilded Rose Refactoring Kata

This repository contains the C# xUnit starter for the Gilded Rose Refactoring Kata. For background on the exercise, see Emily Bache's [Why Developers LOVE The Gilded Rose Kata](https://youtu.be/Mt4XpGxigT4) and [Writing Good Tests for the Gilded Rose Kata](http://coding-is-like-cooking.info/2013/03/writing-good-tests-for-the-gilded-rose-kata/).


## How to use this Kata

Read the [Gilded Rose requirements](GildedRoseRequirements.md) and start in [`csharp.xUnit/`](csharp.xUnit/). With the .NET 10 SDK, run this from the repository root:

```sh
dotnet test csharp.xUnit/GildedRose.sln
```

## Tooling and approach

The xUnit tests cover individual inventory rules, including what happens on the sell-by date and at zero quality. `ApprovalTest.ThirtyDays` uses Verify.Xunit to compare 30 days of inventory output with a [checked-in snapshot](csharp.xUnit/GildedRoseTests/ApprovalTest.ThirtyDays.verified.txt).

The refactor kept that snapshot unchanged while moving the daily rules into item-specific methods. `UpdateQuality` still updates each existing `Item` in place. The Conjured rule came in a separate change: focused tests cover the faster quality loss, and only the affected Conjured output changed in the snapshot.

GitHub Actions runs the suite and collects coverage with Coverlet. A Python check requires 100% line and branch coverage for the updater, including its private helpers. See the [local coverage command](csharp.xUnit/README.md#inventory-characterization-tests) to reproduce the CI check.

## History of the exercise

Terry Hughes created the [original C# kata](https://github.com/NotMyself/GildedRose). Bobby Johnson described it in [Refactor This: The Gilded Rose Kata](https://web.archive.org/web/20240525015111/https://iamnotmyself.com/refactor-this-the-gilded-rose-kata/). This starter comes from [Emily Bache's adaptation](https://github.com/emilybache/GildedRose-Refactoring-Kata), which added the starter tests and approval fixtures.

See the [MIT license](license.txt) and [contributing notes](CONTRIBUTING.md).
