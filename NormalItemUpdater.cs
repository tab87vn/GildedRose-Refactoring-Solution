namespace csharpcore
{
    internal class NormalItemUpdater : ItemUpdater
    {
        public NormalItemUpdater(Item item) : base(item)
        {
            // NOP
        }

        public override void DoUpdateQuality()
        {
            DecreaseQuality(item);
            DecreaseSellIn(item);

            if (SellDateHasPassed(item)) {
                DecreaseQuality(item);
            }
        }
    }
}