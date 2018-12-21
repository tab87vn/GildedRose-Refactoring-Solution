namespace csharpcore
{
    internal class BackstageItemUpdater : ItemUpdater
    {
        public BackstageItemUpdater(Item item) : base(item)
        {
        }

        public override void DoUpdateQuality()
        {
            IncreaseQuality(item);

            if (item.SellIn < DOUBLE_DEGRATION_STARTS_BEFORE)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < TRIPLE_DEGRATION_STARTS_BEFORE)
            {
                IncreaseQuality(item);
            }

            DecreaseSellIn(item);

            if (PassedSellDate(item)) {
                item.Quality = MIN_QUALITY;
            }
        }
    }    
}