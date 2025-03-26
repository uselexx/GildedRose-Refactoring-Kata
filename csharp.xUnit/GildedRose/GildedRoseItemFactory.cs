namespace GildedRoseKata;

public static class GildedRoseItemFactory
{
    public static GildedRoseItem Create(Item item)
    {
        return item.Name switch
        {
            "Aged Brie" => new AgedBrie(item),
            "Sulfuras, Hand of Ragnaros" => new Sulfuras(item),
            "Backstage passes to a TAFKAL80ETC concert" => new BackstagePassesTAFKA(item),
            "Backstage passes to a GALA concert" => new BackstagePassesGALA(item),
            "Conjured" => new ConjuredItem(item),
            _ => new NormalItem(item),
        };
    }
}
