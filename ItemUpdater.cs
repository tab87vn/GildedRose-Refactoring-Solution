namespace csharpcore
{
    public class ItemUpdater
    {
        protected const int MAX_QUALITY = 50;
        protected const int MIN_QUALITY = 0;
        protected const int DOUBLE_DEGRATION_STARTS_BEFORE = 11;
        protected const int TRIPLE_DEGRATION_STARTS_BEFORE = 6;
        protected Item item;

        public ItemUpdater(Item item)
        {
            this.item = item;
        }

        public virtual void DoUpdateQuality()
        {
            // NOP
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