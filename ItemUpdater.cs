namespace csharpcore
{
    public class ItemUpdater
    {
        const string BACKSTAGE = "Backstage passes to a TAFKAL80ETC concert";
        const string AGEDBRIE = "Aged Brie";
        const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        const int MAX_QUALITY = 50;
        const int MIN_QUALITY = 0;
        const int DOUBLE_DEGRATION_STARTS_BEFORE = 11;
        const int TRIPLE_DEGRATION_STARTS_BEFORE = 6;
        protected Item item;

        private bool isAgedBrie(Item item) {
            return item.Name == AGEDBRIE;
        }

        private bool isBackstage(Item item) {
            return item.Name == BACKSTAGE;
        }

        private bool isSulfuras(Item item) {
            return item.Name == SULFURAS;
        }


        public ItemUpdater(Item item)
        {
            this.item = item;
        }

        public void DoUpdateQuality()
        {
            updateIndividualItem(item);
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

        private void updateIndividualItem(Item item)
        {   
            if (isAgedBrie(item))
            {
                AgedBrieItemUpdater updater = new AgedBrieItemUpdater(item);
                updater.DoUpdateQuality();

            }
            else if (isBackstage(item))
            {
                UpdateBackstageItemQuality(item);
            }
            else if (isSulfuras(item))
            {
                UpdateSulfurasItemQuality();
            }
            else
            {
                UpdateNormalItemQualilty(item);
            }
        }

        private void UpdateSulfurasItemQuality()
        {
            // NOP
        }

        private void UpdateNormalItemQualilty(Item item)
        {
            decreaseQuality(item);
            decreaseSellIn(item);

            if (passedSellDate(item)) {
                decreaseQuality(item);
            }
        }

        private void UpdateBackstageItemQuality(Item item)
        {
            increaseQuality(item);

                if (item.SellIn < DOUBLE_DEGRATION_STARTS_BEFORE)
                {
                    increaseQuality(item);
                }

                if (item.SellIn < TRIPLE_DEGRATION_STARTS_BEFORE)
                {
                    increaseQuality(item);
                }

                decreaseSellIn(item);

                if (passedSellDate(item)) {
                    item.Quality = MIN_QUALITY;
                }
        }
    }
}