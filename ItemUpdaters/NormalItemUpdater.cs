using GildedRoseKata.Models;

namespace GildedRoseKata.ItemUpdaters
{
    internal class NormalItemUpdater : ItemUpdater
    {
        public NormalItemUpdater(Item item) : base(item)
        {
            // NOP
        }

        public override void DoUpdateQuality()
        {
            DecreaseSellInByOne();

            if (SellDateHasPassed())
            {
                DecreaseQualityBy(2 * BASE_VALUE_CHANGE_PER_DAY);
            }
            else
            {
                DecreaseQualityBy(BASE_VALUE_CHANGE_PER_DAY);
            }
        }
    }
}