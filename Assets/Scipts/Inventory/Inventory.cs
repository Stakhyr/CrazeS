using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    List<Item> itemList;
    public event EventHandler OnItemListChanged;

    public Inventory() 
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.PowerPotion, amount = 1 });

    }

    public void AddItem(Item item) 
    {
        if (item.IsStackable()) 
        {
            bool itemAlreadyIninventory = false;
            foreach(Item inventoryItem in itemList) 
            {
                if (inventoryItem.itemType == item.itemType) 
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyIninventory = true;
                }
            }
            if (!itemAlreadyIninventory) 
            {
                itemList.Add(item);
            }
        }
        else 
        {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item) 
    {
        if (item.IsStackable()) 
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory!=null && itemInInventory.amount <= 0) 
            {
                itemList.Remove(item);
            }
        }
        else 
        {
            itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);

    }

    public List<Item> GetItemList() 
    {
        return itemList;
    }
}
     