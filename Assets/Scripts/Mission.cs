using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
[CreateAssetMenu(fileName = "Mission", menuName = "Missions/Mission")]
public class Mission : ScriptableObject
{
    public new string name;
    public string description;
    public enum spec{build, repair, name};
    public spec type = spec.name; 
    public float payout;
    public float expearned;

    public float budget;

    public GameObject pc;
}
