namespace GildedRoseKata;

public static class GildedRoseItemFactory
{
    public static GildedRoseItem Create(Item item)
    {
        return item.Name switch
        {
            ItemConstants.AGED_BRIE => new AgedBrie(item),
            ItemConstants.SULFURAS => new Sulfuras(item),
            ItemConstants.BACKSTAGE_TAFKA => new BackstagePassesTAFKA(item),
            ItemConstants.BACKSTAGE_GALA => new BackstagePassesGALA(item),
            ItemConstants.CONJURED => new ConjuredItem(item),
            _ => new NormalItem(item),
        };
    }
}
