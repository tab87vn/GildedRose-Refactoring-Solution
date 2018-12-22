using GildedRoseKata.Models;

namespace GildedRoseKata.ItemUpdaters
{
    public class NormalItemUpdater : DefaultItemBehavior, IItemUpdater
    {
        private const int MIN_QUALITY = 0;

        // This denotes how fast an item quality degrades depending on the type of item.
        // Normal items are NOT affected by this factor (i.e. factor is 1)
        protected int qualityDecreaseFactor = 1;

        public NormalItemUpdater(Item item) : base(item)
        {
            // NOP
        }

        public void DoUpdateQuality()
        {
            DecreaseSellInByOne();

            // Degradation speed is x2 if the sell date has passed
            int qualityDecreaseSpeed = SellDateHasPassed() ? 2 : 1;
            DecreaseQualityBy(
                qualityDecreaseFactor * qualityDecreaseSpeed * BASE_VALUE_CHANGE_PER_DAY);
        }

        // Reduces item quality as long as it's not less than 0
        protected void DecreaseQualityBy(int value)
        {
            if (item.Quality > MIN_QUALITY)
            {
                item.Quality = item.Quality - value < MIN_QUALITY ?
                    MIN_QUALITY : item.Quality - value;
            }
        }
    }
}