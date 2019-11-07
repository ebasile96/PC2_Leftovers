using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetStateBase : MonoBehaviour
{
    protected PetController pet;

    private void Awake()
    {
        pet = GetComponentInParent<PetController>();
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
