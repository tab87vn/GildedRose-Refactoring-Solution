using GildedRoseKata.Models;

namespace GildedRoseKata.ItemUpdaters
{
    public abstract class DefaultItemBehavior
    {
        protected const int BASE_VALUE_CHANGE_PER_DAY = 1;

        protected Item item;

        public DefaultItemBehavior(Item item)
        {
            this.item = item;
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