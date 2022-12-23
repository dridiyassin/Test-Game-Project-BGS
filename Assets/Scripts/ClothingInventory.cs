using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothingInventory : MonoBehaviour
{
    [System.Serializable]
    public struct Slot
    {
        public Button slotButton;
        public Clothing slotItem;
    }

    public Slot equipedHairSlot;
    public Slot equipedTorsoSlot;
    public Slot equipedLegsSlot;


    public Slot[] slots;

    public static ClothingInventory Instance;
    void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        UpdateUI();
    }
    void ClearUI()
    {
        foreach (var slot in slots)
        {
            slot.slotButton.transform.GetChild(0).gameObject.GetComponent<Image>().enabled = false;
        }
    }
    public void UpdateUI()
    {
        ClearUI();
        List<Clothing> items = Inventory.Instance.clothingInventory;

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] != null)
            {
                slots[i].slotButton.transform.GetChild(0).gameObject.GetComponent<Image>().enabled = true;
                slots[i].slotButton.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = items[i].clothingList[0];
                slots[i].slotItem = items[i];
                SetButtonEvent(slots[i]);
            }
        }
    }

    void SetButtonEvent(Slot slt)
    {
        slt.slotButton.onClick.AddListener(delegate { PlayerClothing.Instance.SetClothing(slt.slotItem); });
    }


    public void EquipTorso(TorsoClothing clothingItem)
    {
        equipedTorsoSlot.slotItem = clothingItem;
        equipedTorsoSlot.slotButton.transform.GetChild(1).gameObject.SetActive(true);
        equipedTorsoSlot.slotButton.transform.GetChild(1).GetComponent<Image>().sprite = clothingItem.clothingList[0];
    }

    public void EquipLegs(LegsClothing clothingItem)
    {
        equipedLegsSlot.slotItem = clothingItem;
        equipedLegsSlot.slotButton.transform.GetChild(1).gameObject.SetActive(true);
        equipedLegsSlot.slotButton.transform.GetChild(1).GetComponent<Image>().sprite = clothingItem.clothingList[0];
    }

    public void EquipHair(HairClothing clothingItem)
    {
        equipedHairSlot.slotItem = clothingItem;
        equipedHairSlot.slotButton.transform.GetChild(1).gameObject.SetActive(true);
        equipedHairSlot.slotButton.transform.GetChild(1).GetComponent<Image>().sprite = clothingItem.clothingList[0];
    }
    public void UnEquipTorso()
    {
        equipedTorsoSlot.slotItem = null;

        equipedTorsoSlot.slotButton.transform.GetChild(1).gameObject.SetActive(false);
        PlayerClothing.Instance.torsoClothing = null;
        PlayerClothing.Instance.RefreshClothes();
    }
    public void UnEquipLegs()
    {
        equipedTorsoSlot.slotItem = null;

        equipedLegsSlot.slotButton.transform.GetChild(1).gameObject.SetActive(false);
        PlayerClothing.Instance.legsClothing = null;
        PlayerClothing.Instance.RefreshClothes();
    }
    public void UnEquipHair()
    {
        equipedTorsoSlot.slotItem = null;

        equipedHairSlot.slotButton.transform.GetChild(1).gameObject.SetActive(false);
        PlayerClothing.Instance.hairClothing = null;
        PlayerClothing.Instance.RefreshClothes();
    }
}
