using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCPart : MonoBehaviour
{
    new public string name = "PC Part";
    public bool used = false;
    public bool placed = false;
    public float price = 0;
    public float appeal = 0;
    public int minimumLevel = 0;
    public string type = "part";
    private bool checked_ = false;
    public BoxCollider c;
    public Rigidbody r;
    void Start()
    {        
        gameObject.name = name;   
    }

    void Update()
    {
        if (gameObject.tag != type && checked_ == false)
        {
            Debug.LogError(name + " type is set incorrectly - please check now");
            checked_ = true;
        }
        else
        {
            checked_ = true;
        }

        if (placed == true)
        { 
            keepinplace();
        }
    }
    private void Awake()
    {
        c = GetComponent<BoxCollider>();
        r = GetComponent<Rigidbody>();
    }

    public void Sell()
    {
        if (placed == false)
        {
            Destroy(gameObject);
        }
    }

    public void PlacePart(Transform position)
    {
        c.enabled = false;
        r.useGravity = false;
        r.isKinematic = true;
        transform.position = position.position;
        transform.rotation = position.rotation;
        transform.parent = position;            
    }
    public void RemovePart(Transform position)
    {
        if (placed == true)
        {
            transform.position = new Vector3(transform.position.x + .45f, transform.position.y, transform.position.z);
            transform.parent = null;
            c.enabled = true;
            r.useGravity = true;
            r.isKinematic = false;
            placed = false;       
        }    
    }

    void keepinplace()
    {
        transform.position = transform.parent.position;
        transform.rotation = transform.parent.rotation;
    }

}
