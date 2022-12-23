using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryContent : MonoBehaviour
{
    // Start is called before the first frame update
    public Image[] slots;

    public static InventoryContent Instance;
    void Awake()
    {
        Instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        List<Item> items = Inventory.Instance.itemsInventory;

        for (int i = 0; i < items.Count; i++)
        {
            slots[i].sprite = items[i].icon;
        }
    }
}
