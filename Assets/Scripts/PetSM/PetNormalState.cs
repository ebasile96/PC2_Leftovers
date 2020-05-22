using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetNormalState : PetStateBase
{
    public PetStateBase idleState;
    public PetStateBase runState;

    public override void Enter()
    {
        pet.NormalRunPet();
        pet.SetColorNormalAura();
    }

    public override void Tick()
    {
        if (pet.player.isSwapPlayer == false)
        {
            pet.MovePet(GameManager.instance.Inputmgr.horizontalPet, GameManager.instance.Inputmgr.verticalPet);
        }
        else if (pet.player.isSwapPlayer == true)
        {
            pet.MovePet(GameManager.instance.Inputmgr.horizontal, GameManager.instance.Inputmgr.vertical);
        }
        pet.animator.SetTrigger("GoToRunning");
        if (pet.movement * pet.moveSpeed == new Vector3(0, 0, 0))
        {
            pet.ChangeState(idleState);
        }

        //if (GameManager.instance.Inputmgr.runPet == 1)
        //{
        //  pet.ChangeState(runState);
        //}

        if (pet.player.isSwapPlayer == false)
        {
            pet.RunControllPet(GameManager.instance.Inputmgr.runPet, runState);
        }
        else if (pet.player.isSwapPlayer == true)
        {
            pet.RunControllPet(GameManager.instance.Inputmgr.runPlayer, runState);
        }
    }
}
