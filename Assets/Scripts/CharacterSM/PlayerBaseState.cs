using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : MonoBehaviour
{

    protected PlayerController player;

    private void Awake()
    {
        player = GetComponentInParent<PlayerController>();
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