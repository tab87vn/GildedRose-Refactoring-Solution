using GildedRoseKata.Models;

namespace GildedRoseKata.ItemUpdaters
{
    // A common interface for all the Item Updater classes
    public interface IItemUpdater
    {
        void DoUpdateQuality();
    }
}