using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motherboard : PCPart
{
    public Transform[] memSlots;
    public GameObject[] ramSticks;
    public Transform[] cpuSlots;
    public GameObject[] cpuSticks;
    public Transform[] gpuSlots;
    public GameObject[] gpuSticks;
    public bool hasRam;
    public bool hasCpu;
    public bool hasGpu;
    public float TotalWorth;
    public float TotalAppeal;

    // Start is called before the first frame update
    void Start()
    {
        TotalWorth = price;
        r = GetComponent<Rigidbody>();
        c = GetComponent<BoxCollider>();
    }

    private void Awake()
    {
        int p = 0;
        int childrennumber = gameObject.transform.childCount;
        for (int i = 0; i < childrennumber; i++)
        {
            Transform g = gameObject.transform.GetChild(i);
            if (g.tag == "memorySlot")
            {
                if (p < memSlots.Length)
                {
                    memSlots[p] = g;
                    p++;
                }
            }else
            if (g.tag == "cpuSlot")
            {
                p = 0;
                if (p < cpuSlots.Length)
                {
                    cpuSlots[p] = g;
                    p++;
                }
            }else
            if (g.tag == "gpuSlot")
            {
                p = 0;
                if (p < gpuSlots.Length)
                {
                    gpuSlots[p] = g;
                    p++;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.I))
        {
            RemoveRam(1);
            CheckIFHasRam();
        }*/
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Memory>())
        {
            Memory m = collision.gameObject.GetComponent<Memory>();
            if (collision.gameObject.tag == "Memory")
            {
                Debug.Log("Hit Motherboard");
                //Get Motherboard Memory Transforms
                CheckRam(m);
                CheckIFHasRam();
                return;
            }
        }

        if (collision.gameObject.GetComponent<Cpu>())
        {
            Cpu c = collision.gameObject.GetComponent<Cpu>();
            if (collision.gameObject.tag == "CPU")
            {
                Debug.Log("Hit Motherboard - CPU");
                //Get Motherboard Memory Transforms
                CheckCpu(c);
                CheckIFHasCpu();
                return;
            }
        }

        if (collision.gameObject.GetComponent<Gpu>())
        {
            Gpu g = collision.gameObject.GetComponent<Gpu>();
            if (collision.gameObject.tag == "GPU")
            {
                Debug.Log("Hit Motherboard - GPU");
                //Get Motherboard Memory Transforms
                CheckGpu(g);
                CheckIFHasGpu();
                return;
            }
        }
    }

    #region RamChecking
    public void CheckIFHasRam()
    {
        for (int i = 0; i < ramSticks.Length; i++)
        {
            if (ramSticks[i] != null)
            {
                hasRam = true;
                break;
            }
            else
            {
                hasRam = false;
            }
        }
    }

    public void CheckRam(Memory m)
    {
        for (int i = 0; i < memSlots.Length; i++)
        {
            if (memSlots[i].GetChild(0).name == "pos" && m.placed == false)
            {
                memSlots[i].GetChild(0).name = "ram";
                TotalWorth += m.price;
                TotalAppeal += m.appeal;
                m.PlacePart(memSlots[i].GetChild(0).transform);
                m.placed = true;
                ramSticks[i] = m.gameObject;
                break;
            }

        }
    }

    public void RemoveRam(int index)
    {
        if (ramSticks[index] != null && placed == false)
        {
            Memory m = ramSticks[index].GetComponent<Memory>();
            TotalWorth -= m.price;
            TotalAppeal -= m.appeal;
            memSlots[index].GetChild(0).name = "pos";
            m.RemovePart(memSlots[index].transform);
            ramSticks[index] = null;
        }
    }
    #endregion

    #region CPUChecking
    public void CheckIFHasCpu()
    {
        for (int i = 0; i < cpuSticks.Length; i++)
        {
            if (cpuSticks[i] != null)
            {
                hasCpu = true;
                break;
            }
            else
            {
                hasCpu = false;
            }
        }
    }
    public void CheckCpu(Cpu c)
    {
        for (int i = 0; i < cpuSlots.Length; i++)
        {
            if (cpuSlots[i].GetChild(0).name == "pos" && c.placed == false)
            {
                cpuSlots[i].GetChild(0).name = "cpu";
                TotalWorth += c.price;
                TotalAppeal += c.appeal;
                c.PlacePart(cpuSlots[i].GetChild(0).transform);
                c.placed = true;
                cpuSticks[i] = c.gameObject;
                break;
            }

        }
    }
    public void RemoveCpu(int index)
    {
        if (cpuSticks[index] != null && placed == false)
        {
            Cpu m = cpuSticks[index].GetComponent<Cpu>();
            TotalWorth += m.price;
            TotalAppeal += m.appeal;
            cpuSlots[index].GetChild(0).name = "pos";
            m.RemovePart(cpuSlots[index].transform);
            cpuSticks[index] = null;
        } 
    }
    #endregion

    #region GPUChecking
    public void CheckIFHasGpu()
    {
        for (int i = 0; i < gpuSticks.Length; i++)
        {
            if (gpuSticks[i] != null)
            {
                hasGpu = true;
                break;
            }
            else
            {
                hasGpu = false;
            }
        }
    }
    public void CheckGpu(Gpu c)
    {
        for (int i = 0; i < gpuSlots.Length; i++)
        {
            if (gpuSlots[i].GetChild(0).name == "pos" && c.placed == false)
            {
                gpuSlots[i].GetChild(0).name = "gpu";
                TotalWorth += c.price;
                TotalAppeal += c.appeal;
                c.PlacePart(gpuSlots[i].GetChild(0).transform);
                c.placed = true;
                gpuSticks[i] = c.gameObject;
                break;
            }

        }
    }
    public void RemoveGpu(int index)
    {
        if (gpuSticks[index] != null && placed == false)
        {
            Gpu m = gpuSticks[index].GetComponent<Gpu>();
            TotalWorth -= m.price;
            TotalAppeal -= m.appeal;
            gpuSlots[index].GetChild(0).name = "pos";
            m.RemovePart(cpuSlots[index].transform);
            gpuSticks[index] = null;
        }
    }
    #endregion
}
