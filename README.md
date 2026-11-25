# Gilded Rose: an AI coding workflow

This fork uses the Gilded Rose kata to show how coding agents take a GitHub issue through implementation and pull request review. Orca manages the worktrees where agents work on separate branches. OMP is the coding agent used in those worktrees.

## From issue to reviewed pull request

1. **Define the change in an issue.** Settle ambiguous requirements and give the agent observable acceptance criteria. [Issue #10](https://github.com/kubalobo/GildedRose-Refactoring-Kata-jlobodecki/issues/10), for example, specifies exactly which item names count as Conjured and which lines of the existing snapshot may change.
2. **Give the issue to a coding agent.** In an Orca worktree, OMP uses the issue and the [repository instructions](AGENTS.md) to guide its edits and local checks. The resulting [pull request #12](https://github.com/kubalobo/GildedRose-Refactoring-Kata-jlobodecki/pull/12) links back to the issue so a reviewer can compare the patch with the original request.
3. **Review the patch and its checks.** The `orca-bots` account posts an [automated PR review](https://github.com/kubalobo/GildedRose-Refactoring-Kata-jlobodecki/pull/12#issuecomment-7176170461). Separately, [GitHub Actions](.github/workflows/dotnet-tests.yml) runs the tests and checks updater coverage. The review gives the maintainer feedback on the diff; CI reports whether the executable checks passed.

## Original kata and attribution

Terry Hughes created the [original C# kata](https://github.com/NotMyself/GildedRose). Bobby Johnson described it in [Refactor This: The Gilded Rose Kata](https://web.archive.org/web/20240525015111/https://iamnotmyself.com/refactor-this-the-gilded-rose-kata/). This starter comes from [Emily Bache's adaptation](https://github.com/emilybache/GildedRose-Refactoring-Kata), which added the starter tests and approval fixtures.

For the exercise itself, see the [requirements](GildedRoseRequirements.md) and [C# build and test instructions](csharp.xUnit/README.md). Emily Bache explains the approach in [Why Developers LOVE The Gilded Rose Kata](https://youtu.be/Mt4XpGxigT4) and [Writing Good Tests for the Gilded Rose Kata](http://coding-is-like-cooking.info/2013/03/writing-good-tests-for-the-gilded-rose-kata/). You can [support her katas on Patreon](https://www.patreon.com/EmilyBache).

See the [MIT license](license.txt) and [contributing notes](CONTRIBUTING.md).
