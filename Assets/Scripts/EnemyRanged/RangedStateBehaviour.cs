using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedStateBehaviour : MonoBehaviour
{
    public PatrolAgent ranged;
    private void Awake()
    {
        ranged = GetComponentInParent<PatrolAgent>();
    }

    public virtual void Enter()
    {

    }

    public virtual void Tick()
    {

    }

    public virtual void Exit()
    {

    }
}
