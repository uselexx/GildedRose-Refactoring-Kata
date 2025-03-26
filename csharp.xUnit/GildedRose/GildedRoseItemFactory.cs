namespace GildedRoseKata;

public static class GildedRoseItemFactory
{
    public static GildedRoseItem Create(Item item)
    {
        GildedRoseItem baseItem = item.Name switch
        {
            ItemConstants.AGED_BRIE => new AgedBrie(item),
            ItemConstants.SULFURAS => new Sulfuras(item),
            ItemConstants.BACKSTAGE_TAFKA => new BackstagePassesTAFKA(item),
            ItemConstants.BACKSTAGE_GALA => new BackstagePassesGALA(item),
            _ => new NormalItem(item),
        };

        if (item.Name.Contains(ItemConstants.CONJURED))
        {
            baseItem = new ConjuredItemDecorator(baseItem);
        }
        return baseItem;
    }
}
