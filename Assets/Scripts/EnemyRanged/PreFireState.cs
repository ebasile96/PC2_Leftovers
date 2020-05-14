using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFireState : RangedStateBehaviour
{
    public RangedStateBehaviour movementState;
    public RangedStateBehaviour attackState;
    private float timerForShoot;

    public override void Enter()
    {

    }

    public override void Tick()
    {
        ranged.agent.isStopped = true;
        ranged.anim.SetTrigger("GoToIdle");
        ranged.LookTarget();
        ranged.ActiveLineRender();
        ranged.SetDirectionOfAttack();
        timerForShoot += (1 * Time.deltaTime);
        if (timerForShoot >= 1)
        {
            ranged.ChangeState(attackState);
        }
    }

    public override void Exit()
    {
        ranged.DisactiveLineRender();
        timerForShoot = 0;
    }
}
