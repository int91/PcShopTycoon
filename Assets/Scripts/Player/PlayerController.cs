using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float Money;
    [SerializeField] public int Level;
    [SerializeField] public float Experience;
    [SerializeField] public float MaxEXP;
    public Text money;
    public bool Shopping;
    public bool canlook;
    public bool OnPc;
    public Canvas shopcanvas;
    public Canvas OnPCCanvas;

    public Camera PlayerCam;
    public Camera MonitorCam;
    // Start is called before the first frame update
    void Start()
    {
        shopcanvas.enabled = false;
    }

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;  // 0 = Disabled vSync
        Application.targetFrameRate = 144;
        MaxEXP = 100;
        OnPCCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkshopping();
        checklevel();
        LeavePC();
        money.text = "Money: $"+ Money;
    }

    void checklevel(){
        if (Experience >= MaxEXP){
            Level++;
            Experience -= MaxEXP;
            MaxEXP += 100;
            //MaxEXP += Experience * 1.15f; //Testing Adapative System.
        }
    }
    void checkcheats()
    {
        foreach (Process pro in Process.GetProcesses())
        {
            if (pro.ProcessName.ToLower().Contains("cheat") && pro.ProcessName.ToLower().Contains("engine"))
            {
                Application.Quit();
            }
        }
    }
    void checkshopping()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!Shopping)
            {
                Shopping = true;
                UnityEngine.Debug.Log("Opening Shop");
                shopcanvas.enabled = true;
            }
            else
            {
                Shopping = false;
                UnityEngine.Debug.Log("Closing Shop");
                shopcanvas.enabled = false;
            }
        }
    }
    public void checkonpc()
    {
        Shopping = true;
        OnPc = true;
        PlayerCam.enabled = false;
        MonitorCam.enabled = true;
    }

    void LeavePC(){
        if (Input.GetKeyDown(KeyCode.Escape) && MonitorCam != null)
        {
            if (MonitorCam.enabled){
                Shopping = false;
                OnPc = false;
                PlayerCam.enabled = true;
                MonitorCam.enabled = false;
            }
        }
    }
}
