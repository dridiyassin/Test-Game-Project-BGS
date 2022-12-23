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

    public void UpdateUI()
    {
        List<Clothing> items = Inventory.Instance.clothingInventory;

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] != null)
            {
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
}
