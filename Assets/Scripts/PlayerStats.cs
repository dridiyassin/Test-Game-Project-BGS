using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public float Coins;
    public TextMeshProUGUI coinsTxt;
    public static PlayerStats Instance;


    public ShopKeeper currentShopKeeper;

    bool isNearShop = false;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(isNearShop)
            {
                ShopContent.Instance.shopPanel.SetActive(true);
                ShopContent.Instance.UpdateContent();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("ShopKeeper"))
        {
            currentShopKeeper = other.gameObject.GetComponent<ShopKeeper>();
            isNearShop = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("ShopKeeper"))
        {
            currentShopKeeper = null;
            isNearShop = false;
            ShopContent.Instance.shopPanel.SetActive(false);
        }
    }
}
