using System;
using System.Collections.Generic;

public class InventoryManager
{
    public int slotLimit = 5;
    private readonly List<Item> items = new();

    public IReadOnlyList<Item> Items => items;

    public float CurrentWeight
    {
        get
        {
            float total = 0f;
            foreach(var i in items)
            {
                if(i != null) total += i.weight;
            }
            return total;
        }
    }

    public event Action? OnInventoryChanged;

    public bool AddItem(Item item)
    {
        if(items.Count >= slotLimit || item == null)
            return false;
        items.Add(item);
        OnInventoryChanged?.Invoke();
        return true;
    }

    public bool RemoveItem(Item item)
    {
        bool removed = items.Remove(item);
        if(removed) OnInventoryChanged?.Invoke();
        return removed;
    }
}
