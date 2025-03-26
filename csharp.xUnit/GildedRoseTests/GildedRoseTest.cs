using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

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
    public void AgedBrie_IncreasesInQuality()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(21, items[0].Quality);
        Assert.Equal(9, items[0].SellIn);
    }

    [Fact]
    public void AgedBrie_QualityDoesNotExceed50()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(50, items[0].Quality);
        Assert.Equal(9, items[0].SellIn);
    }

    [Fact]
    public void AgedBrie_IncreasesInQualityTwiceAsFastAfterSellInDate()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 20 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(22, items[0].Quality);
        Assert.Equal(-1, items[0].SellIn);
    }

    [Fact]
    public void AgedBrie_QualityDoesNotExceed50AfterSellInDate()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 49 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(50, items[0].Quality);
        Assert.Equal(-1, items[0].SellIn);
    }

    [Fact]
    public void BackstagePassesGALA_IncreaseInQuality()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a GALA concert", SellIn = 15, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(22, Items[0].Quality);
    }

    [Fact]
    public void BackstagePassesGALA_IncreaseInQualityBy2_When10DaysOrLess()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a GALA concert", SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(23, Items[0].Quality);
    }

    [Fact]
    public void BackstagePassesGALA_IncreaseInQualityBy3_When5DaysOrLess()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a GALA concert", SellIn = 5, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(24, Items[0].Quality);
    }

    [Fact]
    public void BackstagePassesGALA_QualityDropsToZeroAfterConcert()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a GALA concert", SellIn = 0, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(0, Items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_IncreaseInQuality()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(21, Items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_IncreaseInQualityBy2_When10DaysOrLess()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(22, Items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_IncreaseInQualityBy3_When5DaysOrLess()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(23, Items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_QualityDropsToZeroAfterConcert()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(0, Items[0].Quality);
    }

    [Fact]
    public void Sulfuras_QualityRemainsConstant()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(80, items[0].Quality);
        Assert.Equal(5, items[0].SellIn);
    }

    [Fact]
    public void Sulfuras_SellInRemainsConstant()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(80, items[0].Quality);
        Assert.Equal(0, items[0].SellIn);
    }

    [Fact]
    public void Sulfuras_QualityDoesNotChangeAfterSellInDate()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(80, items[0].Quality);
        Assert.Equal(-1, items[0].SellIn);
    }

    [Fact]
    public void Sulfuras_QualityRemainsMax()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(80, items[0].Quality);
        Assert.Equal(10, items[0].SellIn);
    }

    [Fact]
    public void NormalItem_QualityDecreases()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Normal Item", SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(19, items[0].Quality);
        Assert.Equal(9, items[0].SellIn);
    }

    [Fact]
    public void NormalItem_QualityDecreasesTwiceAsFastAfterSellInDate()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Normal Item", SellIn = 0, Quality = 20 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(18, items[0].Quality);
        Assert.Equal(-1, items[0].SellIn);
    }

    [Fact]
    public void NormalItem_QualityDoesNotGoNegative()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Normal Item", SellIn = 10, Quality = 0 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(0, items[0].Quality);
        Assert.Equal(9, items[0].SellIn);
    }

    [Fact]
    public void ConjuredItem_QualityDecreasesTwiceAsFast()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Conjured", SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(18, items[0].Quality);
        Assert.Equal(9, items[0].SellIn);
    }

    [Fact]
    public void ConjuredItem_QualityDecreasesTwiceAsFastAfterSellInDate()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Conjured", SellIn = -1, Quality = 20 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(16, items[0].Quality);
        Assert.Equal(-2, items[0].SellIn);
    }

    [Fact]
    public void ConjuredItem_QualityDoesNotGoNegative()
    {
        IList<Item> items = new List<Item> { new Item { Name = "Conjured", SellIn = 10, Quality = 0 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(0, items[0].Quality);
        Assert.Equal(9, items[0].SellIn);
    }

}