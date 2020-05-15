using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class AttackState : RangedStateBehaviour
{
    public RangedStateBehaviour movementState;
    public override void Enter()
    {
        //ranged.actualDestPoint += 1;
        
    }

    public override void Tick()
    {
        ranged.anim.SetTrigger("GoToIdle");
        ranged.attackTimer += 1;
        //ranged.agent.isStopped = true;
        //ranged.SetDirectionOfAttack();
        if (ranged.isAttack == false)
        {
            ranged.Attack();
        }
        else if (ranged.isAttack == true && ranged.attackTimer >= ranged.maxTimerAttack)
        {
            ranged.attackTimer = 0;
            ranged.ChangeState(movementState);
        }
    }

    public override void Exit()
    {
        ranged.isAttack = false;
        ranged.actualDestPoint += 1;
    }
}
