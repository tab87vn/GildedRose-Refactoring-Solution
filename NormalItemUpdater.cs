namespace csharpcore
{
    internal class NormalItemUpdater : ItemUpdater
    {
        public NormalItemUpdater(Item item) : base(item)
        {
        }

        public override void DoUpdateQuality()
        {
            decreaseQuality(item);
            decreaseSellIn(item);

            if (passedSellDate(item)) {
                decreaseQuality(item);
            }
        }
    }
}