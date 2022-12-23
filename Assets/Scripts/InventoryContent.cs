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

    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void ClearUI()
    {
        foreach (var slot in slots)
        {
            slot.sprite = null;
        }
    }
    public void UpdateUI()
    {
        ClearUI();
        for (int i = 0; i < Inventory.Instance.itemsInventory.Count; i++)
        {
            Debug.Log("Rerendring " + slots[i]);
 
                slots[i].sprite = Inventory.Instance.itemsInventory[i].icon;

        }
    }
}
