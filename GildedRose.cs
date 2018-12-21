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

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != AGEDBRIE && Items[i].Name != BACKSTAGE)
                {
                    if (Items[i].Quality > MIN_QUALITY)
                    {
                        if (Items[i].Name != SULFURAS)
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < MAX_QUALITY)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == BACKSTAGE)
                        {
                            if (Items[i].SellIn < DOUBLE_DEGRATION_STARTS_BEFORE)
                            {
                                if (Items[i].Quality < MAX_QUALITY)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < TRIPLE_DEGRATION_STARTS_BEFORE)
                            {
                                if (Items[i].Quality < MAX_QUALITY)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != SULFURAS)
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != AGEDBRIE)
                    {
                        if (Items[i].Name != BACKSTAGE)
                        {
                            if (Items[i].Quality > MIN_QUALITY)
                            {
                                if (Items[i].Name != SULFURAS)
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < MAX_QUALITY)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
