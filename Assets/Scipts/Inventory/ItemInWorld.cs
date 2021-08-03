using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInWorld : MonoBehaviour
{
    private Item item;
    private SpriteRenderer spriteRenderer;
    private TextMeshPro textMeshPro;

   
    public static ItemInWorld SpawnIteamInWorld(Vector3 position, Item item) 
    {

        Transform spawnedItem = Instantiate(ItemAssets.Instance.pfItemInWorld,position, Quaternion.identity);

        ItemInWorld itemInWorld = spawnedItem.GetComponent<ItemInWorld>();
        itemInWorld.SetItem(item);

        return itemInWorld;
    }


    public void SetItem(Item item) 
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        if (item.amount > 1)
        {
            textMeshPro.SetText(item.amount.ToString());
        }
        else
        {
            textMeshPro.SetText("");
        }



    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Transform spawnedItem = ItemAssets.Instance.pfItemInWorld;
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();


    }

    public Item GetItem() 
    {
        return item;
    }

    public void DestroySelf() 
    {
        Destroy(gameObject);
        
    }

    public static ItemInWorld DropItem(Vector3 pos, Item item)
    {
        float randX = Random.Range(-3f, 3f);
        ItemInWorld droppedItem = SpawnIteamInWorld(new Vector3(50,2,0), item);
        //droppedItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(3f, 2f), ForceMode2D.Impulse);

        return droppedItem;
    }


    public static ItemInWorld Drop(Vector3 position, Transform prefab)
    {

        Transform spawnedItem = Instantiate(prefab, position, Quaternion.identity);

        ItemInWorld itemInWorld = spawnedItem.GetComponent<ItemInWorld>();
        //itemInWorld.SetItem(item);

        return itemInWorld;
    }
}
