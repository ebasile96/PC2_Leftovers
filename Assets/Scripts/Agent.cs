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
    
    

    public virtual void CheckInput() { }
 
}
