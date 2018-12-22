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

            // Quality increase speed is x2 if the sell date has passed
            int qualityIncreaseSpeed = SellDateHasPassed() ? 2 : 1;
            IncreaseQualityBy(qualityIncreaseSpeed * BASE_VALUE_CHANGE_PER_DAY);
        }

        // Increases item quality as long as it's no more than 50
        protected void IncreaseQualityBy(int value)
        {
            if (item.Quality < MAX_QUALITY)
            {
                item.Quality = item.Quality + value > MAX_QUALITY ?
                    MAX_QUALITY : item.Quality + value;
            }
        }
    }
}