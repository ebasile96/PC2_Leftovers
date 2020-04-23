using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : RangedStateBehaviour
{
    public RangedStateBehaviour attackState;

    public override void Enter()
    {

    }

    public override void Tick()
    {
        ranged.agent.isStopped = false;
        ranged.GotoNextPoint();

        if(ranged.destPoint == ranged.actualDestPoint)
        {
            ranged.ChangeState(attackState);
        }
    }

    public override void Exit()
    {

    }
}
