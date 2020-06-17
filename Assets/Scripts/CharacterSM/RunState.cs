using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : PlayerBaseState
{
    public PlayerBaseState idleState;
    public PlayerBaseState normalState;

    public override void Enter()
    {
        //player.animator.SetTrigger("GoToRunning");
        player.SuperRunPlayer();
        player.CreateVfxRun(player.transform, GameManager.instance.Vfxmgr.vfxRunCharacter, false);
    }

    public override void Tick()
    {
        //player.animator.SetTrigger("GoToRunning");

        player.Move(GameManager.instance.Inputmgr.horizontal, GameManager.instance.Inputmgr.vertical);

        if (player.movement * player.moveSpeed != new Vector3(0, 0, 0))
        {
            player.animator.SetTrigger("GoToRunning");
        }
        else if (player.movement * player.moveSpeed == new Vector3(0, 0, 0))
        {
            player.animator.SetTrigger("GoToIdle");
        }
        player.isMoving = true;
        //player.RotationPlayer();
        /*if (player.movement * player.moveSpeed == new Vector3(0, 0, 0))
        {
            player.ChangeState(idleState);
        }*/

            if (GameManager.instance.Inputmgr.runPlayer != 1)
            {
                if (player.movement * player.moveSpeed == new Vector3(0, 0, 0))
                {
                    player.ChangeState(idleState);
                }
                else
                {
                    player.ChangeState(normalState);
                }
            }

        StartCoroutine(player.SwapPG());
    }

    public override void Exit()
    {
        player.isMoving = false;
        player.DestroyVfxRun();
    }

}
