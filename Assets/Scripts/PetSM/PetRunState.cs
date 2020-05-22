﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetRunState : PetStateBase
{
    public PetStateBase idleState;
    public PetStateBase normalState;

    public override void Enter()
    {
        //player.animator.SetTrigger("GoToRunning");
        pet.SuperRunPet();
        pet.SetColorRunAura();
    }

    public override void Tick()
    {
        //player.animator.SetTrigger("GoToRunning");
        if (pet.player.isSwapPlayer == false)
        {
            pet.MovePet(GameManager.instance.Inputmgr.horizontalPet, GameManager.instance.Inputmgr.verticalPet);
        }
        else if (pet.player.isSwapPlayer == true)
        {
            pet.MovePet(GameManager.instance.Inputmgr.horizontal, GameManager.instance.Inputmgr.vertical);
        }
        if (pet.movement * pet.moveSpeed != new Vector3(0, 0, 0))
        {
            pet.animator.SetTrigger("GoToRunning");
        }
        else if (pet.movement * pet.moveSpeed == new Vector3(0, 0, 0))
        {
            pet.animator.SetTrigger("GoToIdle");
        }

        //player.RotationPlayer();
        /*if (player.movement * player.moveSpeed == new Vector3(0, 0, 0))
        {
            player.ChangeState(idleState);
        }*/
        if (pet.player.isSwapPlayer == false)
        {
            if (GameManager.instance.Inputmgr.runPet != 1)
            {
                if (pet.movement * pet.moveSpeed == new Vector3(0, 0, 0))
                {
                    pet.ChangeState(idleState);
                }
                else
                {
                    pet.ChangeState(normalState);
                }
            }
        }
        else if(pet.player.isSwapPlayer == true)
        {
            if (GameManager.instance.Inputmgr.runPlayer != 1)
            {
                if (pet.movement * pet.moveSpeed == new Vector3(0, 0, 0))
                {
                    pet.ChangeState(idleState);
                }
                else
                {
                    pet.ChangeState(normalState);
                }
            }
        }
    }

    public override void Exit()
    {

    }

}
