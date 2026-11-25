﻿using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class GildedRoseTest
{
    private const string OrdinaryItem = "Elixir of the Mongoose";
    private const string Brie = "Aged Brie";
    private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
    private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";

    [Theory]
    [InlineData(1, 10, 0, 9)]
    [InlineData(0, 10, -1, 8)]
    [InlineData(0, 1, -1, 0)]
    [InlineData(0, 0, -1, 0)]
    public void OrdinaryItemsDegradeFasterAfterExpiryWithoutGoingBelowZero(
        int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        UpdateAndAssert(OrdinaryItem, sellIn, quality, expectedSellIn, expectedQuality);
    }

    [Theory]
    [InlineData("Conjured Mana Cake", 1, 10, 0, 8)]
    [InlineData("Conjured Mana Cake", 0, 10, -1, 6)]
    [InlineData("Conjured Elixir", -1, 10, -2, 6)]
    [InlineData("Conjured Elixir", 1, 1, 0, 0)]
    [InlineData("Conjured Elixir", 0, 3, -1, 0)]
    public void ConjuredItemsDegradeTwiceAsFastWithoutGoingBelowZero(
        string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        UpdateAndAssert(name, sellIn, quality, expectedSellIn, expectedQuality);
    }

    [Theory]
    [InlineData("ConjuredMana Cake")]
    [InlineData("conjured Mana Cake")]
    [InlineData("Mana Cake (Conjured Edition)")]
    [InlineData(null)]
    public void NamesWithoutTheExactConjuredPrefixDegradeNormally(string name)
    {
        UpdateAndAssert(name, 0, 10, -1, 8);
    }

    [Theory]
    [InlineData(1, 48, 0, 49)]
    [InlineData(0, 48, -1, 50)]
    [InlineData(0, 49, -1, 50)]
    [InlineData(1, 50, 0, 50)]
    public void BrieImprovesFasterAfterExpiryWithoutExceedingFifty(
        int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        UpdateAndAssert(Brie, sellIn, quality, expectedSellIn, expectedQuality);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(-1)]
    public void SulfurasNeverChanges(int sellIn)
    {
        UpdateAndAssert(Sulfuras, sellIn, 80, sellIn, 80);
    }

    [Theory]
    [InlineData(11, 20, 10, 21)]
    [InlineData(10, 20, 9, 22)]
    [InlineData(6, 20, 5, 22)]
    [InlineData(5, 20, 4, 23)]
    [InlineData(1, 20, 0, 23)]
    [InlineData(0, 20, -1, 0)]
    [InlineData(10, 49, 9, 50)]
    [InlineData(5, 48, 4, 50)]
    public void BackstagePassesFollowConcertThresholdsAndCapQuality(
        int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        UpdateAndAssert(BackstagePass, sellIn, quality, expectedSellIn, expectedQuality);
    }

    [Fact]
    public void UpdateQualityMutatesTheOriginalItemsInTheCallerList()
    {
        var elixir = new Item { Name = OrdinaryItem, SellIn = 1, Quality = 10 };
        var brie = new Item { Name = Brie, SellIn = 0, Quality = 48 };
        var items = new List<Item> { elixir };
        var app = new GildedRose(items);
        items.Add(brie);

        app.UpdateQuality();

        Assert.Same(elixir, items[0]);
        Assert.Same(brie, items[1]);
        Assert.Equal(0, elixir.SellIn);
        Assert.Equal(9, elixir.Quality);
        Assert.Equal(-1, brie.SellIn);
        Assert.Equal(50, brie.Quality);
    }

    private static void UpdateAndAssert(
        string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        var item = new Item { Name = name, SellIn = sellIn, Quality = quality };

        new GildedRose([item]).UpdateQuality();

        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}