using GildedRoseKata.Models;

namespace GildedRoseKata.ItemUpdaters
{
    public class ConjuredItemUpdater : NormalItemUpdater
    {
        public ConjuredItemUpdater(Item item) : base(item)
        {
            itemTypeQualityDecreaseFactor = 2;
        }
    }
}