namespace GildedRoseKata;

public static class GildedRoseItemFactory
{
    public static GildedRoseItem Create(Item item)
    {
        return item.Name switch
        {
            "Aged Brie" => new AgedBrie(item),
            "Sulfuras, Hand of Ragnaros" => new Sulfuras(item),
            "Backstage passes to a TAFKAL80ETC concert" => new BackstagePasses(item),
            "Conjured" => new ConjuredItem(item),
            _ => new NormalItem(item),
        };
    }
}
