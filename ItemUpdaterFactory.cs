namespace csharpcore
{
    public static class ItemUpdaterFactory
    {
        public static ItemUpdater GetUpdater(Item item) {
            ItemUpdater updater = new ItemUpdater(item);
            return updater;
        }
    }

}