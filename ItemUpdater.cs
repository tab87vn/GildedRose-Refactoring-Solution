namespace csharpcore
{
    public class ItemUpdater
    {
        protected const string BACKSTAGE = "Backstage passes to a TAFKAL80ETC concert";
        protected const string AGEDBRIE = "Aged Brie";
        protected const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        protected const int MAX_QUALITY = 50;
        protected const int MIN_QUALITY = 0;
        protected const int DOUBLE_DEGRATION_STARTS_BEFORE = 11;
        protected const int TRIPLE_DEGRATION_STARTS_BEFORE = 6;
        protected Item item;

        public ItemUpdater(Item item)
        {
            this.item = item;
        }

        public void DoUpdateQuality()
        {
            switch (item.Name) {
                case AGEDBRIE:
                    new AgedBrieItemUpdater(item).DoUpdateQuality();
                  break;
                case BACKSTAGE:
                    new BackstageItemUpdater(item).DoUpdateQuality();
                    break;
                case SULFURAS:
                    new SulfurasItemUpdater(item).DoUpdateQuality();
                    break;
                default:
                    new NormalItemUpdater(item).DoUpdateQuality();
                    break;
            }
        }

        protected void increaseQuality(Item item) {
            if (item.Quality < MAX_QUALITY)
            {
                item.Quality = item.Quality + 1;
            }
        }

        protected void decreaseQuality(Item item) {
            if (item.Quality > MIN_QUALITY)
            {
                item.Quality = item.Quality - 1;
            }
        }

        protected void decreaseSellIn(Item item) {
            item.SellIn = item.SellIn - 1;
        }

        protected  bool passedSellDate(Item item) {
            return item.SellIn < 0;
        }
    }
}