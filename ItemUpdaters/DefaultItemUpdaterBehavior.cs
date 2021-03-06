using GildedRoseKata.Models;

namespace GildedRoseKata.ItemUpdaters
{
    // Provides the most common behaviours for all ItemUpdater instances
    public abstract class DefaultItemUpdaterBehavior
    {
        protected const int BASE_VALUE_CHANGE_PER_DAY = 1;

        protected Item item;

        public DefaultItemUpdaterBehavior(Item item)
        {
            this.item = item;
        }

        protected void DecreaseSellInByOne()
        {
            item.SellIn = item.SellIn - BASE_VALUE_CHANGE_PER_DAY;
        }

        protected bool SellDateHasPassed()
        {
            return item.SellIn < 0;
        }
    }
}