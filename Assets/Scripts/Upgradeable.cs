using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgradeable : MonoBehaviour
{
    public float price;
    public int minimumlevel; //Not implemented yet as I haven't finished the store or even most of the game yet.
    [Header("Walls Only")]
    public GameObject wall;
    [Header("Buildable Only")]
    public GameObject sign;
    public GameObject buildable;
    // Start is called before the first frame update
    void Start()
    {
        minimumlevel = 0; // For now    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy(GameObject player){
        var m = player.GetComponent<PlayerController>();
        if (m.Money >= price && m.Level >= minimumlevel){
            m.Money -= price;
            Instantiate(buildable, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            Destroy(sign);
            Debug.Log("Bought storage for " + "$" + price);
        }
    }

    public void Sell(GameObject player){
        var m = player.GetComponent<PlayerController>();
        if (m.Money >= price && m.Level >= minimumlevel){
            m.Money -= price;
            Destroy(wall);
            Debug.Log("Bought Company Expansion for " + "$" + price);
        }
    }

}
