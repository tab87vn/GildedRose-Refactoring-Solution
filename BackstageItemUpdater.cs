namespace csharpcore
{
    internal class BackstageItemUpdater : ItemUpdater
    {
        public BackstageItemUpdater(Item item) : base(item)
        {
        }

        public override void DoUpdateQuality()
        {
            increaseQuality(item);

            if (item.SellIn < DOUBLE_DEGRATION_STARTS_BEFORE)
            {
                increaseQuality(item);
            }

            if (item.SellIn < TRIPLE_DEGRATION_STARTS_BEFORE)
            {
                increaseQuality(item);
            }

            decreaseSellIn(item);

            if (passedSellDate(item)) {
                item.Quality = MIN_QUALITY;
            }
        }
    }    
}