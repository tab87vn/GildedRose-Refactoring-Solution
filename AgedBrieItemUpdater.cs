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
            DecreaseSellInByOne();

            if (SellDateHasPassed())
            {
                IncreaseQualityBy(2 * BASE_VALUE_CHANGE_PER_DAY);
            }
            else
            {
                IncreaseQualityBy(BASE_VALUE_CHANGE_PER_DAY);
            }
        }
    }
}