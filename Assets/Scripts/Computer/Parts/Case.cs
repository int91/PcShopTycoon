using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : PCPart
{
    public string FinishedName;
    public Transform[] hddSlots;
    public GameObject[] hddOBJ;
    public Transform[] ssdSlots;
    public GameObject[] ssdOBJ;
    public Transform[] motherboardSlots;
    public GameObject[] motherboardOBJ;

    public bool hasStorage;
    public bool hasMotherboard;
    public bool pcFinished;

    public float TotalWorth;
    public float TotalAppeal;

    private void Awake()
    {
        FinishedName = name;
        TotalWorth = price;
        int p = 0;
        int childrennumber = gameObject.transform.childCount;
        for (int i = 0; i < childrennumber; i++)
        {
            Transform g = gameObject.transform.GetChild(i);
            if (g.tag == "motherboardSlot")
            {
                if (p < motherboardSlots.Length)
                {
                    motherboardSlots[p] = g;
                    p++;
                }
            }
            else
            if (g.tag == "hddSlot")
            {
                p = 0;
                if (p < hddSlots.Length)
                {
                    hddSlots[p] = g;
                    p++;
                }
            }
            else
            if (g.tag == "ssdSlot")
            {
                p = 0;
                if (p < ssdSlots.Length)
                {
                    ssdSlots[p] = g;
                    p++;
                }
            }
        }
    }

    public void Update()
    {
        if (hasStorage == true && hasMotherboard == true)
        {
            pcFinished = true;
        }
        else
        {
            pcFinished = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Motherboard>())
        {
            Motherboard m = collision.gameObject.GetComponent<Motherboard>();
            if (collision.gameObject.tag == "Motherboard" && m.hasRam && m.hasGpu && m.hasCpu)
            {
                Debug.Log("Hit Case - Motherboard");
                //Get Motherboard Memory Transforms
                CheckMotherboard(m);
                CheckIFHasMotherboard();
                return;
            }
        }
        if (collision.gameObject.GetComponent<SSD>())
        {
            SSD m = collision.gameObject.GetComponent<SSD>();
            if (collision.gameObject.tag == "Storage")
            {
                Debug.Log("Hit Case - SSD");
                //Get Motherboard Memory Transforms
                CheckSSD(m);
                CheckIFHasSSD();
                return;
            }
        }
        if (collision.gameObject.GetComponent<Hdd>())
        {
            Hdd m = collision.gameObject.GetComponent<Hdd>();
            if (collision.gameObject.tag == "Storage")
            {
                Debug.Log("Hit Case - HDD");
                //Get Motherboard Memory Transforms
                CheckHDD(m);
                CheckIFHasHDD();
                return;
            }
        }
    }

    #region CheckMotherboard
    public void CheckIFHasMotherboard()
    {
        for (int i = 0; i < motherboardOBJ.Length; i++)
        {
            if (motherboardOBJ[i] != null)
            {
                hasMotherboard = true;
                break;
            }
            else
            {
                hasMotherboard = false;
            }
        }
    }

    public void CheckMotherboard(Motherboard m)
    {
        for (int i = 0; i < motherboardSlots.Length; i++)
        {
            if (motherboardSlots[i].GetChild(0).name == "pos" && m.placed == false)
            {
                motherboardSlots[i].GetChild(0).name = "motherboard";
                m.PlacePart(motherboardSlots[i].GetChild(0).transform);
                m.placed = true;
                TotalWorth += m.TotalWorth;
                TotalAppeal += m.TotalAppeal;
                motherboardOBJ[i] = m.gameObject;
                break;
            }

        }
    }

    public void RemoveMotherboard(int index)
    {
        if (motherboardOBJ[index] != null)
        {
            Motherboard m = motherboardOBJ[index].GetComponent<Motherboard>();
            TotalWorth -= m.TotalWorth;
            TotalAppeal -= m.TotalAppeal;
            motherboardSlots[index].GetChild(0).name = "pos";
            m.RemovePart(motherboardSlots[index].transform);
            motherboardOBJ[index] = null;
        }
    }
    #endregion

    #region CheckHDD
    public void CheckIFHasHDD()
    {
        for (int i = 0; i < hddOBJ.Length; i++)
        {
            if (hddOBJ[i] != null)
            {
                hasStorage = true;
                break;
            }
            else
            {
                hasStorage = false;
            }
        }
    }

    public void CheckHDD(Hdd h)
    {
        for (int i = 0; i < hddSlots.Length; i++)
        {
            if (hddSlots[i].GetChild(0).name == "pos" && h.placed == false)
            {
                hddSlots[i].GetChild(0).name = "hdd";
                h.PlacePart(hddSlots[i].GetChild(0).transform);
                h.placed = true;
                TotalWorth += h.price;
                hddOBJ[i] = h.gameObject;
                break;
            }

        }
    }

    public void RemoveHDD(int index)
    {
        if (hddOBJ[index] != null)
        {
            Hdd m = hddOBJ[index].GetComponent<Hdd>();
            TotalWorth -= m.price;
            hddSlots[index].GetChild(0).name = "pos";
            m.RemovePart(hddSlots[index].transform);
            hddOBJ[index] = null;
        }
    }
    #endregion

    #region CheckSSD
    public void CheckIFHasSSD()
    {
        for (int i = 0; i < ssdOBJ.Length; i++)
        {
            if (ssdOBJ[i] != null)
            {
                hasStorage = true;
                break;
            }
            else
            {
                hasStorage = false;
            }
        }
    }

    public void CheckSSD(SSD s)
    {
        for (int i = 0; i < ssdSlots.Length; i++)
        {
            if (ssdSlots[i].GetChild(0).name == "pos" && s.placed == false)
            {
                ssdSlots[i].GetChild(0).name = "ssd";
                TotalWorth += s.price;
                s.PlacePart(ssdSlots[i].GetChild(0).transform);
                s.placed = true;
                ssdOBJ[i] = s.gameObject;
                break;
            }

        }
    }

    public void RemoveSSD(int index)
    {
        if (ssdOBJ[index] != null)
        {
            SSD m = ssdOBJ[index].GetComponent<SSD>();
            TotalWorth -= m.price;
            ssdSlots[index].GetChild(0).name = "pos";
            m.RemovePart(ssdSlots[index].transform);
            ssdOBJ[index] = null;
        }
    }
    #endregion
}
