using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partsBox : MonoBehaviour
{
    public GameObject g;
    public void Openbox()
    {
        Instantiate(g, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
