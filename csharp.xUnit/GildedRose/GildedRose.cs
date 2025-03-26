using System.Collections.Generic;

namespace GildedRoseKata;




public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }


    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            var strategy = ItemUpdateStrategyFactory.GetStrategy(item);
            strategy.Update(item);
        }
    }
}