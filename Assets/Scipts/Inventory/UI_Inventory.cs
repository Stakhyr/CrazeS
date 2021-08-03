using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] private Transform itemSlotContainer;
    [SerializeField] private Transform itemSlotTemplate;
    [SerializeField] private Image imageIcon;
    [SerializeField] private TextMeshProUGUI uiText;

    [SerializeField] Transform pref;

    private Character character;

    private void Awake()
    {


        Debug.Log(itemSlotContainer.name);
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = -1;
        int y = 1;
        float itemSlotSellSize = 30f;
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
            {
                // Use item
                //inventory.UseItem(item);
                Debug.Log("Use Item");
            };
            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>
            {
                // Drop item
                Item duplicateItem = new Item { itemType = item.itemType, amount = item.amount };

                ItemInWorld.SpawnIteamInWorld(new Vector3(48, 2, 0), duplicateItem);

                inventory.RemoveItem(item);

                Debug.Log("FFFF");

            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotSellSize, y * itemSlotSellSize);

            //Image image = itemSlotRectTransform.GetComponentInChildren<Image>();
            imageIcon.sprite = item.GetSprite();

            //TextMeshProUGUI uiText = itemSlotRectTransform.GetComponentInChildren<TextMeshProUGUI>();
            Debug.Log(uiText.name);
            if (item.amount > 1)
            {
                uiText.SetText(item.amount.ToString());
            }
            else
            {
                uiText.SetText("");
            }
            x++;
            if (x > 3)
            {
                x = 0;
                //meybe y--
                y++;
            }
        }
    }
}
