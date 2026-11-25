﻿using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            var item = Items[i];
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                continue;
            }

            var sellInBeforeUpdate = item.SellIn;
            item.SellIn = sellInBeforeUpdate - 1;

            switch (item.Name)
            {
                case "Aged Brie":
                    UpdateAgedBrie(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateBackstagePass(item, sellInBeforeUpdate);
                    break;
                default:
                    UpdateDegradingItem(item, sellInBeforeUpdate);
                    break;
            }
        }
    }

    private static void UpdateAgedBrie(Item item)
    {
        if (item.Quality < 50)
        {
            var increase = item.SellIn < 0 ? 2 : 1;
            item.Quality = Math.Min(50, item.Quality + increase);
        }
    }

    private static void UpdateBackstagePass(Item item, int sellInBeforeUpdate)
    {
        if (item.SellIn < 0)
        {
            item.Quality = 0;
            return;
        }

        if (item.Quality < 50)
        {
            var increase = sellInBeforeUpdate <= 5 ? 3 : sellInBeforeUpdate <= 10 ? 2 : 1;
            item.Quality = Math.Min(50, item.Quality + increase);
        }
    }

    private static void UpdateDegradingItem(Item item, int sellInBeforeUpdate)
    {
        if (item.Quality > 0)
        {
            var decrease = sellInBeforeUpdate > 0 ? 1 : 2;
            if (item.Name is string name && name.StartsWith("Conjured ", StringComparison.Ordinal))
            {
                decrease *= 2;
            }

            item.Quality = Math.Max(0, item.Quality - decrease);
        }
    }
}