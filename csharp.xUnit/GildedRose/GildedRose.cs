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
        for (var i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
            {
                return;
            }

            Items[i].SellIn -= 1;

            if(Items[i].SellIn > 0)
            {
                switch (Items[i].Name)
                {
                    case "Backstage passes to a TAFKAL80ETC concert":
                        if (Items[i].SellIn <= 5)
                        {
                            Items[i].Quality += 3;
                        }
                        else if (Items[i].SellIn <= 10)
                        {
                            Items[i].Quality += 2;
                        }
                        else
                        {
                            Items[i].Quality += 1;
                        }
                        break;
                    case "Aged Brie":
                        Items[i].Quality += 1;
                        break;
                    case "Conjured":
                        Items[i].Quality -= 2;
                        break;
                    default:
                        Items[i].Quality -= 1;
                        break;
                }
            } else
            {
                switch (Items[i].Name)
                {
                    case "Backstage passes to a TAFKAL80ETC concert":
                        Items[i].Quality = 0;
                        break;
                    case "Aged Brie":
                        Items[i].Quality += 2;
                        break;
                    case "Conjured":
                        Items[i].Quality -= 4;
                        break;
                    default:
                        Items[i].Quality -= 2;
                        break;
                }
            }

            if (Items[i].Quality > 50)
            {
                Items[i].Quality = 50;
            }

            if (Items[i].Quality < 0)
            {
                Items[i].Quality = 0;
            }


        }
    }
}