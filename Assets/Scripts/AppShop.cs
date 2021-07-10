using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AppShop : MonoBehaviour
{
    public bool AppShopOpen;
    public GameObject ShopUI;

    // Start is called before the first frame update
    void Start()
    {
        if (AppShopOpen)
        {
            ShopUI.SetActive(true);
        }
        else
        {
            ShopUI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (AppShopOpen)
        {
            ShopUI.SetActive(true);
        }
        else
        {
            ShopUI.SetActive(false);
        }
    }

    public void OpenShop()
    {
        AppShopOpen = true;
    }
    
    public void CloseShop()
    {
        AppShopOpen = false;
    }
}
