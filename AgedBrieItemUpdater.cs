 namespace csharpcore
 {
    public class AgedBrieItemUpdater : ItemUpdater
    {
        public AgedBrieItemUpdater(Item item) : base(item)
        {
            // NOP
        }

        public override void DoUpdateQuality()
        {
            IncreaseQuality(item);
            DecreaseSellIn(item);
            if (PassedSellDate(item)) {
                IncreaseQuality(item);
            }
        }
    }
}