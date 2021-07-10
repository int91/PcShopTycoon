using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public new string name;
    public float Value;

    GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject;
    }

    public void Openbox()
    {
        Destroy(self);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
