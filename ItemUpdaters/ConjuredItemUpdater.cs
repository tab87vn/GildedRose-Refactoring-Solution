using GildedRoseKata.Models;

namespace GildedRoseKata.ItemUpdaters
{
    // A Conjured item quality degrades as it ages, except that
    // its degration speed is twice as fast as a normal item (i.e. factor = 2)
    public class ConjuredItemUpdater : NormalItemUpdater
    {
        public ConjuredItemUpdater(Item item) : base(item)
        {
            qualityDecreaseFactor = 2;
        }
    }
}