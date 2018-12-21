namespace csharpcore
{
    internal class ConjuredItemUpdater : ItemUpdater
    {
        public ConjuredItemUpdater(Item item) : base(item)
        {
            // NOP
        }

        public override void DoUpdateQuality()
        {
            DecreaseQuality(item);
            DecreaseQuality(item);
            DecreaseSellIn(item);

            if (PassedSellDate(item)) {
                DecreaseQuality(item);
            }
        }
    }
}