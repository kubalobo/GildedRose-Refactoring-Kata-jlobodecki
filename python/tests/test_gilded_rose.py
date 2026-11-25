# -*- coding: utf-8 -*-
import unittest

from gilded_rose import Item, GildedRose


class GildedRoseTest(unittest.TestCase):
    def test_normal_item_degrades_twice_as_fast_after_sell_by_date(self):
        item = Item("Elixir of the Mongoose", sell_in=1, quality=10)
        shop = GildedRose([item])

        shop.update_quality()
        self.assertEqual((0, 9), (item.sell_in, item.quality))

        shop.update_quality()
        self.assertEqual((-1, 7), (item.sell_in, item.quality))

    def test_foo(self):
        items = [Item("foo", 0, 0)]
        gilded_rose = GildedRose(items)
        gilded_rose.update_quality()
        self.assertEqual("fixme", items[0].name)

        
if __name__ == '__main__':
    unittest.main()
