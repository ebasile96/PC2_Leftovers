using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [HideInInspector]
    public bool dash;
    [HideInInspector]
    public bool attackMelee;
    [HideInInspector]
    public float rotate;
    [HideInInspector]
    public float forward;
    [HideInInspector]
    public bool stayHere;
    [HideInInspector]
    public bool follow;
    
    

    public virtual void CheckInput() { }
 
}
