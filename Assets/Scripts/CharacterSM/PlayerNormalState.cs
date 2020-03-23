using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalState : PlayerBaseState
{
    public PlayerBaseState idleState;

    public override void Enter()
    {
        //player.animator.SetTrigger("GoToRunning");
    }

    public override void Tick()
    {
        player.animator.SetTrigger("GoToRunning");
        player.Move();
        player.isMoving = true;
        //player.RotationPlayer();
        if (player.movement * player.moveSpeed == new Vector3(0, 0, 0))
        {
            player.ChangeState(idleState);
        }
    }

    public override void Exit()
    {
        player.isMoving = false;
    }

}
