using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;




public class GildedRose
{
    private readonly List<GildedRoseItem> _items;

    public GildedRose(IList<Item> Items)
    {
        _items = Items.Select(GildedRoseItemFactory.Create).ToList();
    }


    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            item.UpdateQuality();
            //var strategy = ItemUpdateStrategyFactory.GetStrategy(item);
            //strategy.Update(item);
        }
    }
}