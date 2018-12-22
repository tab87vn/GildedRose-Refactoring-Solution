using System;
using System.Collections.Generic;
using GildedRoseKata.ItemUpdaters;
using GildedRoseKata.Models;

namespace GildedRoseKata.Handlers
{
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
                ItemUpdaterFactory.GetUpdater(Items[i]).DoUpdateQuality();
            }
        }
    }
}
