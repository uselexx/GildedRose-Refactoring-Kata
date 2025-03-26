namespace GildedRoseKata;


// LEVEL 2 Strategy Pattern

public interface IItemUpdateStrategy
{
    void Update(Item item);
}

public static class ItemUpdateStrategyFactory
{
    public static IItemUpdateStrategy GetStrategy(Item item)
    {
        return item.Name switch
        {
            "Aged Brie" => new AgedBrieStrategy(),
            "Sulfuras, Hand of Ragnaros" => new SulfurasStrategy(),
            "Backstage passes to a TAFKAL80ETC concert" => new BackstagePassesStrategy(),
            "Conjured" => new ConjuredItemStrategy(),
            _ => new NormalItemStrategy(),
        };
    }

    
}

public class NormalItemStrategy : IItemUpdateStrategy
{
    public void Update(Item item)
    {
        item.SellIn--;

        if (item.Quality > 0)
        {
            item.Quality--;
        }

        if (item.SellIn < 0 && item.Quality > 0)
        {
            item.Quality--;
        }
    }
}

public class AgedBrieStrategy : IItemUpdateStrategy
{
    public void Update(Item item)
    {
        item.SellIn--;

        if (item.Quality < 50)
        {
            item.Quality++;
        }

        if (item.SellIn < 0 && item.Quality < 50)
        {
            item.Quality++;
        }
    }
}

public class SulfurasStrategy : IItemUpdateStrategy
{
    public void Update(Item item)
    {

    }
}

public class BackstagePassesStrategy : IItemUpdateStrategy
{
    public void Update(Item item)
    {

        if (item.Quality < 50)
        {
            item.Quality++;

            if (item.SellIn <= 10) item.Quality++;
            if (item.SellIn <= 5) item.Quality++;
        }

        item.SellIn--;

        if (item.SellIn < 0)
        {
            item.Quality = 0;
        }

        // Ensure quality stays within bounds
        if (item.Quality > 50)
        {
            item.Quality = 50;
        }
    }
}

public class ConjuredItemStrategy : IItemUpdateStrategy
{
    public void Update(Item item)
    {
        item.SellIn--;

        if (item.Quality > 0)
        {
            item.Quality -= 2;
        }
        if (item.SellIn < 0 && item.Quality > 0)
        {
            item.Quality -= 2;
        }
    }
}