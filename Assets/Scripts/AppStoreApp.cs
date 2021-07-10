using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AppStoreApp : MonoBehaviour
{
    [Header("UI Elements")]
    public Text confirmationText;
    public Button yesBtn;
    public Button noBtn;
    public Button app;
    public GameObject desktopApp;
    public bool appInstalled;
    bool confirmationMenuOpened;

    // Start is called before the first frame update
    void Start()
    {
        desktopApp.SetActive(false);
        confirmationMenuOpened = false;
        if (appInstalled) { app.gameObject.SetActive(false); desktopApp.SetActive(true);} else { app.gameObject.SetActive(true); desktopApp.SetActive(true);}
    }

    // Update is called once per frame
    void Update()
    {
        if (confirmationMenuOpened)
        {
            confirmationText.enabled = true;
            yesBtn.gameObject.SetActive(true);
            noBtn.gameObject.SetActive(true);
        }
        else
        {
            confirmationText.enabled = false;
            yesBtn.gameObject.SetActive(false);
            noBtn.gameObject.SetActive(false);
        }
    }

    public void askIntall()
    {
        confirmationMenuOpened = true;
        app.gameObject.SetActive(false);
    }

    public void confirmInstall()
    {
        appInstalled = true;
        app.gameObject.SetActive(false);
        confirmationMenuOpened = false;
    }

    public void denyInstall()
    {
        app.gameObject.SetActive(true);
        confirmationMenuOpened = false;
    }
}
