using GildedRoseKata.Models;

namespace GildedRoseKata.ItemUpdaters
{
    public class AgedBrieItemUpdater : DefaultItemBehavior, IItemUpdater
    {
        private const int MAX_QUALITY = 50;

        public AgedBrieItemUpdater(Item item) : base(item)
        {
            // NOP
        }

        public virtual void DoUpdateQuality()
        {
            DecreaseSellInByOne();

            int qualityIncreaseSpeed = SellDateHasPassed() ? 2 : 1;
            IncreaseQualityBy(qualityIncreaseSpeed * BASE_VALUE_CHANGE_PER_DAY);
        }

        protected void IncreaseQualityBy(int value)
        {
            if (item.Quality < MAX_QUALITY)
            {
                item.Quality = item.Quality + value > MAX_QUALITY ? MAX_QUALITY : item.Quality + value;
            }
        }
    }
}