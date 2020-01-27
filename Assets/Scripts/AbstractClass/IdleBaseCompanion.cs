using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBaseCompanion : MonoBehaviour
{
    public delegate void IdleCompanionEvent();
    public IdleCompanionEvent OnIdleCompanion;
}
