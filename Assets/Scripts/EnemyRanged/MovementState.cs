using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : RangedStateBehaviour
{
    public RangedStateBehaviour attackState;
    private bool start = false;

    public override void Enter()
    {
        Debug.Log("entra nell enter diobestia");
        if(start == false)
        ranged.actualDestPoint += 1;
    }

    public override void Tick()
    {
        ranged.anim.SetTrigger("GoToRunning");
        ranged.agent.isStopped = false;
        ranged.GotoNextPoint();

        if(ranged.destPoint == ranged.actualDestPoint)
        {
            ranged.ChangeState(attackState);
        }
    }

    public override void Exit()
    {
        start = true;
    }
}
