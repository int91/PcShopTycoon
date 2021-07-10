using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour
{
    public Transform destination; //Destination to building
    public Transform endpoint; //When you send the truck back, it goes here
    public Transform itemSpawnPos;
    public bool Arrived;
    public bool CanBuy;
    public float TruckSpeed; //Speed of the truck
    private float CheckTime; //Used to check if player bought anything over time.
    public int MaxPurchases;
    public GameObject[] Purchases;
    public GameObject[] g;


    void Awake()
    {
        CheckTime = 30; //Base Time
        //CheckTime = 1; //Testing Time
        MaxPurchases = 15;
        
        for (int i = 0; i < MaxPurchases; i++)
        {
            Purchases[i] = null;
        }
        for (int i = 0; i < MaxPurchases; i++)
        {
            g[i] = null;
        }
    }

    private void FixedUpdate()
    {
        PurchaseCheck();
        if (Arrived == false && CanBuy == false) { Leave(); }
        if (transform.position == endpoint.transform.position)
        {
            CanBuy = true;
            StartCoroutine(checkPurchases());
        }
    }

    void PurchaseCheck()
    {
        if (Purchases[0] != null)
        {
            StartCoroutine(checkPurchases());
        }
    }

    void Arrive()
    {
        if (Arrived)
        {
            CanBuy = false;
            StartCoroutine(spawnParts());
            return;
        }
        else
        {   
            transform.position = Vector3.MoveTowards(transform.position, destination.position, TruckSpeed * Time.deltaTime);
            if (transform.position == destination.transform.position)
            {
                Arrived = true;
            }
        }
    }

    public void Leave()
    {
        Arrived = false;
        transform.position = Vector3.MoveTowards(transform.position, endpoint.position, TruckSpeed * Time.deltaTime);
    }

    IEnumerator checkPurchases()
    {
        yield return new WaitForSeconds(CheckTime);
        if (Purchases[0] != null)
        {
            Arrive();
        }
        else
        {
            Arrive();
        }
    }

    IEnumerator spawnParts()
    {
        for (int i = 0; i < Purchases.Length; i++)
        {
            if (Purchases[i] == null)
            {

            }
            else
            {
                var c = Purchases[i].GetComponent<partsBox>();
                Instantiate(Purchases[i], itemSpawnPos.position, Quaternion.identity);
                c.g = g[i];
                Purchases[i] = null;
                g[i] = null;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
