 namespace  csharpcore
 {
    public class AgedBrieItemUpdater : ItemUpdater
    {
        public AgedBrieItemUpdater(Item item) : base(item)
        {
        }

        public override void DoUpdateQuality()
        {
            increaseQuality(item);
            decreaseSellIn(item);
            if (passedSellDate(item)) {
                increaseQuality(item);
            }
        }
    }
}