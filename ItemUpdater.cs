namespace csharpcore
{
    public class ItemUpdater
    {
        protected const int MAX_QUALITY = 50;
        protected const int MIN_QUALITY = 0;
        protected Item item;

        public ItemUpdater(Item item)
        {
            this.item = item;
        }

        public virtual void DoUpdateQuality()
        {
            // NOP
        }

        protected void IncreaseQuality(Item item) {
            if (item.Quality < MAX_QUALITY)
            {
                item.Quality = item.Quality + 1;
            }
        }

        protected void DecreaseQuality(Item item) {
            if (item.Quality > MIN_QUALITY)
            {
                item.Quality = item.Quality - 1;
            }
        }

        protected void DecreaseSellIn(Item item) {
            item.SellIn = item.SellIn - 1;
        }

        protected  bool SellDateHasPassed(Item item) {
            return item.SellIn < 0;
        }
    }
}