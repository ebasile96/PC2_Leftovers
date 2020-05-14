using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : RangedStateBehaviour
{
    public RangedStateBehaviour attackState;
    public RangedStateBehaviour preFireState;
    private bool start = false;

    public override void Enter()
    {
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
            ranged.ChangeState(preFireState);
        }
    }

    public override void Exit()
    {
        start = true;
    }
}
