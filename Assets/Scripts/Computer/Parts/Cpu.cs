using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cpu : PCPart
{
    public int cpuFrequency;
    public int cpuCores;

    public void setFrequency(int frequency)
    {
        cpuFrequency = frequency;
    }
}
