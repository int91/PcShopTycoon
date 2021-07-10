using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonScript : MonoBehaviour
{
    public Button button;
    public Text itemname;
    public Text price;
    public Text type;
    public PlayerController pc;
    public GameObject g;
    public GameObject partbox;
    public GameObject truck;

    private float DeliveryFee;
    // Start is called before the first frame update
    void Start()
    {
        DeliveryFee = 50.0f;
        truck = GameObject.Find("Truck");
        pc = GameObject.Find("Player").GetComponent<PlayerController>();  
        if (g != null){
            PCPart p;
            p = g.GetComponent<PCPart>();
            if (pc.Level <= p.minimumLevel){
                type.text = p.type;
            if (g.GetComponent<Hdd>())
            {
                type.text = "Hard Drive";
            }else if (g.GetComponent<SSD>())
            {
                type.text = "Solid State Drive";
            }
                  
            itemname.text = p.name;
            price.text = "Price: $" + p.price;
            Transform spawn = GameObject.Find("partsboxspawn").transform;
            }
        }else{
            button.gameObject.SetActive(false);
        }
    }

    public void Buy()
    {
        PCPart s;
        s = g.GetComponent<PCPart>();
        Transform spawn = GameObject.Find("partsboxspawn").transform;
        var p = partbox.GetComponent<partsBox>();
        p.g = g;
        var tc = truck.GetComponent<TruckController>();
        if (tc.CanBuy)
        {
            if (pc.Money >= s.price && pc.Level >= s.minimumLevel)
            {
                pc.Money -= s.price + DeliveryFee;
                price.text = "Price: $" + s.price; 
                for (int i = 0; i < tc.Purchases.Length; i++)
                {
                    if (tc.Purchases[i] == null)
                    {
                        tc.Purchases[i] = partbox;
                        tc.g[i] = p.g;
                        return;
                    }
                    else
                    {
                        //idk
                    }
                }
                Debug.Log("Purchased " + s.name + " for " + price.text);
            }
        }
    }

    void Update()
    {
        PCPart p;
        p = g.GetComponent<PCPart>();
        if (pc.Level >= p.minimumLevel){
            var b = button.GetComponent<Image>();
            b.color = Color.white;
        }else{
            var b = button.GetComponent<Image>();
            b.color = Color.red;
        }
    }
}
