using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerBaseState
{
    public PlayerBaseState normalState;

    public override void Enter()
    {
        
    }

    public override void Tick()
    {
        player.animator.SetTrigger("GoToIdle");
        player.Move();
        if (player.movement * player.moveSpeed != new Vector3(0,0,0))
        {
            player.ChangeState(normalState);
        }
    }
}
