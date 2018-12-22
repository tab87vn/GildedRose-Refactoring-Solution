namespace csharpcore
{
    internal class BackstageItemUpdater : ItemUpdater
    {
        const int DAYS_BEFORE_QUALITY_INCREASES_BY_2 = 11;
        const int DAYS_BEFORE_QUALITY_INCREASES_BY_3 = 6;

        public BackstageItemUpdater(Item item) : base(item)
        {
            // NOP
        }

        public override void DoUpdateQuality()
        {
            if (item.SellIn < DAYS_BEFORE_QUALITY_INCREASES_BY_3)
            {
                IncreaseQualityBy(3);
            }
            else if (item.SellIn < DAYS_BEFORE_QUALITY_INCREASES_BY_2)
            {
                IncreaseQualityBy(2);
            }
            else
            {
                IncreaseQualityBy(BASE_VALUE_CHANGE_PER_DAY);
            }

            DecreaseSellInByOne();

            if (SellDateHasPassed())
            {
                item.Quality = MIN_QUALITY;
            }
        }
    }    
}