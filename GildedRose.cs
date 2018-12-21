using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        const string BACKSTAGE = "Backstage passes to a TAFKAL80ETC concert";
        const string AGEDBRIE = "Aged Brie";
        const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        const int MAX_QUALITY = 50;
        const int MIN_QUALITY = 0;
        const int DOUBLE_DEGRATION_STARTS_BEFORE = 11;
        const int TRIPLE_DEGRATION_STARTS_BEFORE = 6;

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        private bool isAgedBrie(Item item) {
            return item.Name == AGEDBRIE;
        }

        private bool isBackstage(Item item) {
            return item.Name == BACKSTAGE;
        }

        private bool isSulfuras(Item item) {
            return item.Name == SULFURAS;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                updateIndividualItem(Items[i]);
            }
        }

        void increaseQuality(Item item) {
            if (item.Quality < MAX_QUALITY)
            {
                item.Quality = item.Quality + 1;
            }
        }

        void decreaseQuality(Item item) {
            if (item.Quality > MIN_QUALITY)
            {
                if (!isSulfuras(item))
                {
                    item.Quality = item.Quality - 1;
                }
            }
        }

        private void updateIndividualItem(Item item)
        {   
            if (isAgedBrie(item))
            {
                increaseQuality(item);
            }
            else if (isBackstage(item))
            {
                increaseQuality(item);

                if (item.SellIn < DOUBLE_DEGRATION_STARTS_BEFORE)
                {
                    increaseQuality(item);
                }

                if (item.SellIn < TRIPLE_DEGRATION_STARTS_BEFORE)
                {
                    increaseQuality(item);
                }
            }
            else
            {
                decreaseQuality(item);
            }

            if (!isSulfuras(item))
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (isAgedBrie(item))
                {
                    increaseQuality(item);
                }
                else if (isBackstage(item))
                {
                    item.Quality = MIN_QUALITY;
                }
                else
                {
                    decreaseQuality(item);
                }
            }
        }
    }
}