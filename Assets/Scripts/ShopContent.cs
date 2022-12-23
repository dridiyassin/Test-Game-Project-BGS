using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopContent : MonoBehaviour
{

    

    public GameObject shopPanel;

    [System.Serializable]
    public struct ShopSlot 
    {
        public Button itemButton;
        public Clothing item;
        public TextMeshProUGUI price_Txt;

    }

    [System.Serializable]
    public struct ItemSlot
    {
        public Button itemButton;
        public Item item;
        public TextMeshProUGUI price_Txt;
    }

    public ShopSlot[] shopKeeperSlots;
    public ItemSlot[] itemSlots;


   public static ShopContent Instance;
    private void Awake()
    {
        Instance = this;
    }


    void ClearContent()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].price_Txt.text = "";
            itemSlots[i].itemButton.interactable = false;
            itemSlots[i].item = null;
            itemSlots[i].itemButton.onClick.RemoveAllListeners();
        }
            
           
        
    }
    public void UpdateContent()
    {


        ClearContent();
        for (int i = 0; i < Inventory.Instance.itemsInventory.Count; i++)
        {
            itemSlots[i].item = Inventory.Instance.itemsInventory[i];
            itemSlots[i].price_Txt.text = Inventory.Instance.itemsInventory[i].sellPrice.ToString();
            itemSlots[i].itemButton.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = itemSlots[i].item.icon;
            SetSellButton(itemSlots[i]);
        }

        for (int i = 0; i < PlayerStats.Instance.currentShopKeeper.shopItems.Length; i++)
        {
            shopKeeperSlots[i].item = PlayerStats.Instance.currentShopKeeper.shopItems[i];
            shopKeeperSlots[i].price_Txt.text = shopKeeperSlots[i].item.buyPrice.ToString();
            shopKeeperSlots[i].itemButton.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = shopKeeperSlots[i].item.clothingList[0];
            SetBuyButton(shopKeeperSlots[i]);
        }
    }

    void SetSellButton(ItemSlot slot)
    {
        slot.itemButton.interactable = true;
        slot.itemButton.onClick.AddListener(delegate
        {
                slot.itemButton.interactable = false;
                PlayerStats.Instance.Coins += slot.item.sellPrice;
            PlayerStats.Instance.coinsTxt.text = "Coins:  " + PlayerStats.Instance.Coins.ToString();
            Inventory.Instance.RemoveItem(slot.item);
                UpdateContent();
                slot.itemButton.onClick.RemoveAllListeners();
            
        });
    }

    void SetBuyButton(ShopSlot slot)
    {
        slot.itemButton.interactable = true;
        slot.itemButton.onClick.AddListener(delegate
        {
            if (PlayerStats.Instance.Coins >= slot.item.buyPrice)
            {
                PlayerStats.Instance.Coins -= slot.item.buyPrice;
                PlayerStats.Instance.coinsTxt.text = "Coins: " + PlayerStats.Instance.Coins.ToString();
                UpdateContent();
                slot.itemButton.onClick.RemoveAllListeners();
                slot.itemButton.interactable = false;
                Inventory.Instance.AddItem(slot.item);
                
            }
        });
    }
}
