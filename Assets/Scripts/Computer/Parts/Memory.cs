using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : PCPart
{
    public int memoryFrequency;
    public int memoryGigs;

    public void setFrequency(int frequency)
    {
        memoryFrequency = frequency;
    }

}
