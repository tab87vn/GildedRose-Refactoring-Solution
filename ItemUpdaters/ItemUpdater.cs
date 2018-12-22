using GildedRoseKata.Models;

namespace GildedRoseKata.ItemUpdaters
{
    public class ItemUpdater
    {
        protected const int MAX_QUALITY = 50;
        protected const int MIN_QUALITY = 0;
        protected const int BASE_VALUE_CHANGE_PER_DAY = 1;

        protected Item item;

        public ItemUpdater(Item item)
        {
            this.item = item;
        }

        public virtual void DoUpdateQuality()
        {
            // NOP
        }

        protected void IncreaseQualityBy(int value)
        {
            if (item.Quality < MAX_QUALITY)
            {
                item.Quality = item.Quality + value > MAX_QUALITY ? MAX_QUALITY : item.Quality + value;
            }
        }

        protected void DecreaseQualityBy(int value)
        {
            if (item.Quality > MIN_QUALITY)
            {
                item.Quality = item.Quality - value < MIN_QUALITY ? MIN_QUALITY : item.Quality - value;
            }
        }

        protected void DecreaseSellInByOne()
        {
            item.SellIn = item.SellIn - BASE_VALUE_CHANGE_PER_DAY;
        }

        protected  bool SellDateHasPassed()
        {
            return item.SellIn < 0;
        }
    }
}