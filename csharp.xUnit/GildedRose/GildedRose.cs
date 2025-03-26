using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;

// LEVEL 6 Observer Pattern
public class GildedRoseItemObserver(GildedRoseItem item, GildedRose shop) : Observer
{
    public override void Update()
    {
        shop.UpdateItemPriority(item);
    }
}

public class GildedRose
{
    private Dictionary<GildedRoseItem, ItemPriority> _items;

    public enum ItemPriority
    {
        Standard = 0,
        High = 1
    }

    public GildedRose(IList<Item> Items)
    {
        _items = new Dictionary<GildedRoseItem, ItemPriority>();
        foreach (var gildedRoseItem in Items.Select(GildedRoseItemFactory.Create))
        {
            gildedRoseItem.Attach(new GildedRoseItemObserver(gildedRoseItem, this));
            _items.Add(gildedRoseItem, ItemPriority.Standard);
        }
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            item.Key.UpdateQuality();
        }
    }

    public void UpdateItemPriority(GildedRoseItem item)
    {
        if (_items.TryGetValue(item, out _))
        {
            _items[item] = ItemPriority.High;
        }
    }

    public List<GildedRoseItem> HighPriorityItems => _items.Where(kvp => kvp.Value == ItemPriority.High).Select(kvp=> kvp.Key).ToList();
}