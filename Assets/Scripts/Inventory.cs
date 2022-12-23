using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Clothing> clothingInventory = new List<Clothing>();
    public List<Item> itemsInventory = new List<Item>();

    int maxSlots;

    public static Inventory Instance;
    void Awake()
    {
        Instance = this;

        
    }
    private void Start()
    {
        maxSlots = InventoryContent.Instance.slots.Length;
    }


    public void AddItem(Item item)
    {
        if (itemsInventory.Count < maxSlots)
        {
            itemsInventory.Add(item);
            InventoryContent.Instance.UpdateUI();
        }
    }

    public void AddItem(Item[] items)
    {
        if (itemsInventory.Count < maxSlots)
        {
            itemsInventory.AddRange(items);
            InventoryContent.Instance.UpdateUI();
        }
    }
    public void AddItem(Clothing item)
    {
        if (clothingInventory.Count < maxSlots)
        {
            clothingInventory.Add(item);
            ClothingInventory.Instance.UpdateUI();
        }
    }

    public void RemoveItem(Clothing item)
    {

            clothingInventory.Remove(item);
            ClothingInventory.Instance.UpdateUI();
    }

    public void RemoveItem(Item item)
    {
            itemsInventory.Remove(item);
            InventoryContent.Instance.UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
