using System;
using System.Collections.Generic;

namespace GildedRoseKata;

// LEVEL 6 Observer Pattern
public abstract class Observer
{
    public abstract void Update();
}

public abstract class Subject
{
    private List<Observer> observers = new();
    public void Attach(Observer observer)
    {
        observers.Add(observer);
    }
    public void Detach(Observer observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update();
        }
    }
}


// LEVEL 3 Abstract Class
public abstract class GildedRoseItem : Subject
{
    public Item Item;

    public GildedRoseItem(Item item)
    {
        Item = item;
    }

    public abstract void UpdateQuality();

    protected void DecreaseSellIn()
    {
        Item.SellIn--;
        // LEVEL 6
        if (Item.SellIn < 3)
        {
            Notify();
        }
    }

    protected void DecreaseQuality(int amount = 1)
    {
        if (Item.Quality > 0) Item.Quality = Math.Max(0, Item.Quality - amount);
    }

    protected void IncreaseQuality(int amount = 1)
    {
        if (Item.Quality < 50) Item.Quality = Math.Min(50, Item.Quality + amount);
    }
}

public class NormalItem(Item item) : GildedRoseItem(item)
{
    public override void UpdateQuality()
    {
        DecreaseSellIn();

        DecreaseQuality();

        if (Item.SellIn < 0)
        {
            DecreaseQuality();
        }
    }
}

public class AgedBrie(Item item) : GildedRoseItem(item)
{
    public override void UpdateQuality()
    {
        DecreaseSellIn();

        IncreaseQuality();

        // Increase twice as fast
        if (Item.SellIn < 0)
        {
            IncreaseQuality();
        }
    }
}

public class Sulfuras(Item item) : GildedRoseItem(item)
{
    public override void UpdateQuality()
    {
        // Legendary item, never decreases in quality
    }
}

public class BackstagePassesTAFKA(Item item) : GildedRoseItem(item)
{
    public override void UpdateQuality()
    {
        DecreaseSellIn();

        if (Item.SellIn < 0)
        {
            Item.Quality = 0;
        }
        else if (Item.SellIn < 5)
        {
            IncreaseQuality(3);
        }
        else if (Item.SellIn < 10)
        {
            IncreaseQuality(2);
        }
        else
        {
            IncreaseQuality();
        }
    }
}

public class BackstagePassesGALA(Item item) : GildedRoseItem(item)
{
    public override void UpdateQuality()
    {
        DecreaseSellIn();

        if (Item.SellIn < 0)
        {
            Item.Quality = 0;
        }
        else if (Item.SellIn < 5)
        {
            IncreaseQuality(4);
        }
        else if (Item.SellIn < 10)
        {
            IncreaseQuality(3);
        }
        else
        {
            IncreaseQuality(2);
        }
    }
}

public class ConjuredItemDecorator(GildedRoseItem baseItem) : GildedRoseItem(baseItem.Item)
{

    public override void UpdateQuality()
    {
        int initialQuality = Item.Quality;
        baseItem.UpdateQuality();
        int qualityDifference = initialQuality - Item.Quality;

        DecreaseQuality(qualityDifference);
    }
}