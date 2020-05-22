﻿using System.Collections;
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
        player.SetColorRunAura();
    }

    public override void Tick()
    {
        //player.animator.SetTrigger("GoToRunning");
        if (player.isSwapPlayer == false)
        {
            player.Move(GameManager.instance.Inputmgr.horizontal, GameManager.instance.Inputmgr.vertical);
        }
        else if (player.isSwapPlayer == true)
        {
            player.Move(GameManager.instance.Inputmgr.horizontalPet, GameManager.instance.Inputmgr.verticalPet);
        }


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

        if (player.isSwapPlayer == false)
        {
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
        }
        else if(player.isSwapPlayer == true)
        {
            if (GameManager.instance.Inputmgr.runPet != 1)
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
        }

        player.SwapInput();
    }

    public override void Exit()
    {
        player.isMoving = false;
    }

}
