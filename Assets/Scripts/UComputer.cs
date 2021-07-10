using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UComputer : MonoBehaviour
{
    public GameObject pc;
    public PCHolder holder;
    public GameObject b;
    public Case w;
    public Camera MonitorCam;

    public Canvas pcUi;

    public bool pcPower;

    public Canvas osLoading;
    public Canvas osScreen;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("PCHolder");
        holder = pc.GetComponent<PCHolder>();
        MonitorCam.enabled = false;
        pcUi.enabled = false;
        osLoading.enabled = false;
        osScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkHolder();  
        checkInputs();
        checkPcOn();
    }

    void checkHolder(){
        if (holder != null)
        {
            if(holder = pc.GetComponent<PCHolder>())
            {
                if (holder.comp != null){
                    b = holder.comp;
                    w = b.GetComponent<Case>();
                }  
            }       
        }
    }
    void checkInputs(){
        if (Input.GetKeyDown(KeyCode.P))
        {
            TurnOnPC();
        }
    }
    void TurnOnPC()
    {
        holder = pc.GetComponent<PCHolder>();
        b = holder.comp;
        if (b == null)
        {
            pcPower = false;
            pcUi.enabled = false;
            osLoading.enabled = false;
            osScreen.enabled = false;
        } else
        {
            if (pcPower == true){
                pcPower = false;
                osLoading.enabled = false;
                osScreen.enabled = false;
                return;
            }
            pcPower = true;
            pcUi.enabled = true;
            StartCoroutine(loadOS());
        }
    }
    void checkPcOn(){
        if (pcPower == true){
            pcUi.enabled = true;
        }else{
            pcUi.enabled = false;
        }
    }

    IEnumerator loadOS(){
        osLoading.enabled = true;
        yield return new WaitForSeconds(5f);
        osLoading.enabled = false;
        osScreen.enabled = true;
    }
}
