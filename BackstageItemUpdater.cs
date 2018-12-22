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
            IncreaseQuality(item);

            if (item.SellIn < DAYS_BEFORE_QUALITY_INCREASES_BY_3)
            {
                IncreaseQuality(item);
            }

            else if (item.SellIn < DAYS_BEFORE_QUALITY_INCREASES_BY_2)
            {
                IncreaseQuality(item);
            }

            DecreaseSellIn(item);

            if (SellDateHasPassed(item)) {
                item.Quality = MIN_QUALITY;
            }
        }
    }    
}