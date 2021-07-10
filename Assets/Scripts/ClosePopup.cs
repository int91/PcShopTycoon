using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ClosePopup : MonoBehaviour
{
    public Canvas popupCanvas;
    public PlayerController playerController;
    public PlayerLook player;
    public TMP_InputField namebox;
    
    // Start is called before the first frame update
    void Start()
    {
        if (namebox != null){
            namebox.enabled = false;
        }
    }

    public void CloseThePopup(){
        popupCanvas.gameObject.SetActive(false);
    }

    public void StartTheGame(){
        CloseThePopup();
        playerController.canlook = true;
    }

    public void JoinDiscord(){
        Application.OpenURL("https://discord.gg/SX4w9Ws");
    }

    public void PlayGame(){
        SceneManager.LoadScene("SmallOffice");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void NamePc(){
        var hold = player.Holding.GetComponent<Case>();
        hold.FinishedName = namebox.text;
        namebox.enabled = false;
        StartTheGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
