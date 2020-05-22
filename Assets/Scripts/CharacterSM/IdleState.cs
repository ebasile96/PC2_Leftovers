using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerBaseState
{
    public PlayerBaseState normalState;
    public PlayerBaseState runState;

    public override void Enter()
    {
        player.NormalRunPlayer();
        player.SetColorNormalAura();
    }

    public override void Tick()
    {
        player.animator.SetTrigger("GoToIdle");
        if (player.isSwapPlayer == false) 
        {
            player.Move(GameManager.instance.Inputmgr.horizontal, GameManager.instance.Inputmgr.vertical);
        }
        else if (player.isSwapPlayer == true)
        {
            player.Move(GameManager.instance.Inputmgr.horizontalPet, GameManager.instance.Inputmgr.verticalPet);
        }

        if (player.movement * player.moveSpeed != new Vector3(0,0,0))
        {
            player.ChangeState(normalState);
        }

        //if (GameManager.instance.Inputmgr.runPlayer == 1)
        //{
        //  player.ChangeState(runState);
        //}

        if (player.isSwapPlayer == false) 
        {
            player.RunControll(GameManager.instance.Inputmgr.runPlayer, runState);
        }
        else if(player.isSwapPlayer == true)
        {
            player.RunControll(GameManager.instance.Inputmgr.runPet, runState);
        }

        player.SwapInput();
    }
}
