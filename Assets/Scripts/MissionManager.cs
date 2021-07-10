using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public Mission mission;
    public Mission activemission;

    // Start is called before the first frame update
    void Start()
    {
        activemission = mission;
        if (activemission.type.ToString() == "Build"){
            Debug.Log(activemission.type.ToString() + " Mission - Active");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
