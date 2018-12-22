using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }

        [Fact]
        public void UpdateQuality_DecreaseQualityAndSellInByOne() {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 2 }  };        
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal("foo", items[0].Name);
            Assert.Equal(0, items[0].SellIn);
            Assert.Equal(1, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_SellByDateHasPassed_QualityDegradesTwiceAsFast() {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = -1, Quality = 3 }  };            
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();
            
            // Assert            
            Assert.Equal("foo", items[0].Name);
            Assert.Equal(-2, items[0].SellIn);
            Assert.Equal(1, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_QualityCannotBeNegative(){
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 2, Quality = 2 }  };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();
            
            // Assert
            Assert.Equal("foo", items[0].Name);
            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_QualityCannotBeMoreThan50() {
            // Arrange
            IList<Item> items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = -1, Quality = 50 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 49 } 
            };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();
            app.UpdateQuality();

            // Assert
            Assert.Equal("Aged Brie", items[0].Name);
            Assert.Equal(-3, items[0].SellIn);
            Assert.Equal(50, items[0].Quality);

            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", items[1].Name);
            Assert.Equal(1, items[1].SellIn); 
            Assert.Equal(50, items[1].Quality);
        }

        [Fact]
        public void UpdateQuality_SulfurasNeverHasToBeSoldOrDecreasesInQuality() {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 }  };        
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal("Sulfuras, Hand of Ragnaros", items[0].Name);
            Assert.Equal(10, items[0].SellIn);
            Assert.Equal(80, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_SellByDateApproaches_BackstageQualityIncreasesByOne() {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 20 }  };        
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", items[0].Name);
            Assert.Equal(10, items[0].SellIn); 
            Assert.Equal(21, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_10DaysOrLessRemaining_BackstageQualityIncreasesBy2() {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 }  };        
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", items[0].Name);
            Assert.Equal(9, items[0].SellIn); 
            Assert.Equal(22, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_5DaysOrLessRemaining_BackstageQualityIncreasesBy3() {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 }  };                
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", items[0].Name);
            Assert.Equal(4, items[0].SellIn); 
            Assert.Equal(23, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_BackstageQualityDropsTo0AfterTheConcert() {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 20 }  };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", items[0].Name);
            Assert.Equal(-2, items[0].SellIn); 
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_ConjuredItemsDegradeInQualityTwiceAsFast() {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 20 }  };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal("Conjured Mana Cake", items[0].Name);
            Assert.Equal(2, items[0].SellIn);
            Assert.Equal(18, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_SellByDateHasPassed_ConjuredItemsDegradeInQualityTwiceAsFastAsNormalItems()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = -1, Quality = 20 }  };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal("Conjured Mana Cake", items[0].Name);
            Assert.Equal(-2, items[0].SellIn);
            Assert.Equal(16, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_SellByDateHasPassed_ConjuredItemsDegradeInQualityTwiceAsFastAsNormalItems_QualityCannotBeNegative()
        {
            // Arrange
            IList<Item> items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = -1, Quality = 2 }  };
            GildedRose app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal("Conjured Mana Cake", items[0].Name);
            Assert.Equal(-2, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
        }
    }
}