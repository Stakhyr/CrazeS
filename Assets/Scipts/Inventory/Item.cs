using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item
{
   public enum ItemType 
    {
        HealthPotion,
        ManaPotion,
        PowerPotion,


    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite() 
    {
        switch (itemType) 
        {
           
            case ItemType.HealthPotion:     return ItemAssets.Instance.healthPotionSprite;
            case ItemType.ManaPotion:       return ItemAssets.Instance.manaPotionSprite;
            case ItemType.PowerPotion:      return ItemAssets.Instance.powerPotionSprite;
            default: return ItemAssets.Instance.healthPotionSprite;

        }
    }

    public bool IsStackable() 
    {
        switch (itemType) 
        {
            default:
            case ItemType.HealthPotion:
            case ItemType.ManaPotion:
            case ItemType.PowerPotion:
                return true;
            // some case
            //return false;
        }
    }
}
