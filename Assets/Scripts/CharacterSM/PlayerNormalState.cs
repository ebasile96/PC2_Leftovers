using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalState : PlayerBaseState
{
    public PlayerBaseState idleState;
    public PlayerBaseState runState;

    public override void Enter()
    {
        player.NormalRunPlayer();    
    }

    public override void Tick()
    {
        player.animator.SetTrigger("GoToRunning");

        
        player.Move(GameManager.instance.Inputmgr.horizontal, GameManager.instance.Inputmgr.vertical);

        player.isMoving = true;
        //player.RotationPlayer();
        if (player.movement * player.moveSpeed == new Vector3(0, 0, 0))
        {
            player.ChangeState(idleState);
        }

        //if (GameManager.instance.Inputmgr.runPlayer == 1)
        //{
        //  player.ChangeState(runState);
        //}
        
        player.RunControll(GameManager.instance.Inputmgr.runPlayer, runState);

        StartCoroutine(player.SwapPG());
    }

    public override void Exit()
    {
        player.isMoving = false;
    }

}
