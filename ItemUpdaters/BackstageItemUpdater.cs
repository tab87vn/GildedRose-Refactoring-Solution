using GildedRoseKata.Models;

namespace GildedRoseKata.ItemUpdaters
{
    public class BackstageItemUpdater : AgedBrieItemUpdater
    {
        const int DAYS_BEFORE_QUALITY_INCREASES_BY_2 = 11;
        const int DAYS_BEFORE_QUALITY_INCREASES_BY_3 = 6;

        public BackstageItemUpdater(Item item) : base(item)
        {
            // NOP
        }

        public override void DoUpdateQuality()
        {
            IncreaseQualityBy(GetQualityIncreaseValue());
            DecreaseSellInByOne();
            DropQualityToZeroIfSellDateHasPassed();
        }

        private void DropQualityToZeroIfSellDateHasPassed()
        {
            if (SellDateHasPassed())
            {
                item.Quality = 0;
            }
        }

        private int GetQualityIncreaseValue() {
            if (item.SellIn < DAYS_BEFORE_QUALITY_INCREASES_BY_3)
            {
                return 3;
            }
            else if (item.SellIn < DAYS_BEFORE_QUALITY_INCREASES_BY_2)
            {
                return 2;
            }
            else
            {
                return BASE_VALUE_CHANGE_PER_DAY;
            }
        }
    }
}