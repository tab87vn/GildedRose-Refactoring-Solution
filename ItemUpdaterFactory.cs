namespace csharpcore
{
    public static class ItemUpdaterFactory
    {
        const string BACKSTAGE = "Backstage passes to a TAFKAL80ETC concert";
        const string AGEDBRIE = "Aged Brie";
        const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        public static ItemUpdater GetUpdater(Item item) {
            switch (item.Name) {
                case AGEDBRIE:
                    return new AgedBrieItemUpdater(item);
                case BACKSTAGE:
                    return new BackstageItemUpdater(item);
                case SULFURAS:
                    return new SulfurasItemUpdater(item);
                default:
                    return new NormalItemUpdater(item);
            }
        }
    }
}