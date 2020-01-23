using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBase : MonoBehaviour
{
    public delegate void IdleEvent();
    public IdleEvent OnIdle;
}
