using GildedRoseKata.Models;

namespace GildedRoseKata.ItemUpdaters
{
    internal class ConjuredItemUpdater : ItemUpdater
    {
        public ConjuredItemUpdater(Item item) : base(item)
        {
            // NOP
        }

        public override void DoUpdateQuality()
        {
            DecreaseSellInByOne();

            if (SellDateHasPassed())
            {
                DecreaseQualityBy(4 * BASE_VALUE_CHANGE_PER_DAY);
            }
            else
            {
                DecreaseQualityBy(2 * BASE_VALUE_CHANGE_PER_DAY);
            }
        }
    }
}