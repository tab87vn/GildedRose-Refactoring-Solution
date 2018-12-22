using GildedRoseKata.Models;

namespace GildedRoseKata.ItemUpdaters
{
    // Looks at the name of the item type and returns a
    // suitable updater instance for that item
    public static class ItemUpdaterFactory
    {
        const string BACKSTAGE = "Backstage passes to a TAFKAL80ETC concert";
        const string AGEDBRIE = "Aged Brie";
        const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        const string CONJURED = "Conjured Mana Cake";

        public static IItemUpdater GetUpdater(Item item)
        {
            switch (item.Name)
            {
                case AGEDBRIE:
                    return new AgedBrieItemUpdater(item);
                case BACKSTAGE:
                    return new BackstageItemUpdater(item);
                case SULFURAS:
                    // only for the sake of clarity as a Sulfuras item
                    // does not need to be updated
                    return new SulfurasItemUpdater();
                case CONJURED:
                    return new ConjuredItemUpdater(item);
                default:
                    return new NormalItemUpdater(item);
            }
        }
    }
}