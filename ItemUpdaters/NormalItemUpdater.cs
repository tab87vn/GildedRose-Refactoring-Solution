using GildedRoseKata.Models;

namespace GildedRoseKata.ItemUpdaters
{
    public class NormalItemUpdater : DefaultItemBehavior, IItemUpdater
    {
        private const int MIN_QUALITY = 0;

        protected int itemTypeQualityDecreaseFactor;

        public NormalItemUpdater(Item item) : base(item)
        {
            itemTypeQualityDecreaseFactor = 1;
        }

        public void DoUpdateQuality()
        {
            DecreaseSellInByOne();

            int qualityDecreaseSpeed = SellDateHasPassed() ? 2 : 1;
            DecreaseQualityBy(itemTypeQualityDecreaseFactor * qualityDecreaseSpeed * BASE_VALUE_CHANGE_PER_DAY);
        }

        protected void DecreaseQualityBy(int value)
        {
            if (item.Quality > MIN_QUALITY)
            {
                item.Quality = item.Quality - value < MIN_QUALITY ? MIN_QUALITY : item.Quality - value;
            }
        }
    }
}