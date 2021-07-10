using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSortButton : MonoBehaviour
{
    [Header("Categories")]
    public Canvas cpuCategory;
    public Canvas gpuCategory;
    public Canvas motherboardCategory;
    public Canvas caseCategory;
    public Canvas storageCategory;
    public Canvas memoryCategory;
    // Start is called before the first frame update
    void Start()
    {
        cpuCategory.enabled = true;
        gpuCategory.enabled = false;
        motherboardCategory.enabled = false;
        caseCategory.enabled = false;
        storageCategory.enabled = false;
        memoryCategory.enabled = false;
    }

    public void Sort(){
        var button = gameObject.GetComponent<Button>();
        if (button.tag == "cpuSort"){
            cpuCategory.enabled = true;
            gpuCategory.enabled = false;
            motherboardCategory.enabled = false;
            caseCategory.enabled = false;
            storageCategory.enabled = false;
            memoryCategory.enabled = false;
        }
        if (button.tag == "gpuSort"){
            gpuCategory.enabled = true;
            cpuCategory.enabled = false;
            motherboardCategory.enabled = false;
            caseCategory.enabled = false;
            storageCategory.enabled = false;        
            memoryCategory.enabled = false; 
        }
        if (button.tag == "storageSort"){
            storageCategory.enabled = true;
            gpuCategory.enabled = false;
            motherboardCategory.enabled = false;
            caseCategory.enabled = false;
            cpuCategory.enabled = false;
            memoryCategory.enabled = false;
        }
        if (button.tag == "motherboardSort"){
            motherboardCategory.enabled = true;
            gpuCategory.enabled = false;
            cpuCategory.enabled = false;
            caseCategory.enabled = false;
            storageCategory.enabled = false;
            memoryCategory.enabled = false;
        }
        if (button.tag == "caseSort"){
            caseCategory.enabled = true;
            gpuCategory.enabled = false;
            motherboardCategory.enabled = false;
            cpuCategory.enabled = false;
            storageCategory.enabled = false;
            memoryCategory.enabled = false;
        }
        if (button.tag == "memorySort"){
            memoryCategory.enabled = true;
            caseCategory.enabled = false;
            gpuCategory.enabled = false;
            motherboardCategory.enabled = false;
            cpuCategory.enabled = false;
            storageCategory.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
