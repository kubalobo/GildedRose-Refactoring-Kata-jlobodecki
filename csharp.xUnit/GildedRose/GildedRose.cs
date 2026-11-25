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

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                UpdateBackstagePass(item, sellInBeforeUpdate);
                continue;
            }

            if (item.Name != "Aged Brie")
            {
                if (item.Quality > 0)
                {
                    item.Quality = item.Quality - 1;
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }

            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Quality > 0)
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }
    }

    private static void UpdateBackstagePass(Item item, int sellInBeforeUpdate)
    {
        if (item.Quality < 50)
        {
            item.Quality = item.Quality + 1;

            if (sellInBeforeUpdate < 11)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }

            if (sellInBeforeUpdate < 6)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }

        if (item.SellIn < 0)
        {
            item.Quality = item.Quality - item.Quality;
        }
    }
}