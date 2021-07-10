using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCHolder : MonoBehaviour
{
    public GameObject comp;
    public GameObject holding;
    PlayerLook pl;
    // Start is called before the first frame update
    void Start()
    {
        holding = GameObject.Find("Player Camera");
        pl = holding.GetComponent<PlayerLook>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "CASE")
        {
            var computer = collision.gameObject.GetComponent<Case>();  
            if (computer.pcFinished){
                if (computer.placed == false)
                {         
                    computer.PlacePart(transform);
                    computer.placed = true;
                }
                comp = computer.gameObject;
            } 
        }
    }

    void RemovePC()
    {
        if (comp != null){var pc = comp.gameObject.GetComponent<Case>();
            if (pc.placed == true){
                pl.Holding = comp;
                comp = null;
            }
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
