using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Clothing> clothingInventory = new List<Clothing>();
    public List<Item> itemsInventory = new List<Item>();


    public static Inventory Instance;
    void Awake()
    {
        if (Instance == null) Instance = this;
    }


    
    public void AddItem(Item item)
    {
        itemsInventory.Add(item);
    }

    public void AddItem(Item[] items)
    {
        itemsInventory.AddRange(items);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
