using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetIdleState : PetStateBase
{
    public PetStateBase normalState;
    public PetStateBase runState;

    public override void Enter()
    {
        pet.NormalRunPet();
        pet.SetColorNormalAura();
    }

    public override void Tick()
    {
        pet.animator.SetTrigger("GoToIdle");
        if (pet.player.isSwapPlayer == false)
        {
            pet.MovePet(GameManager.instance.Inputmgr.horizontalPet, GameManager.instance.Inputmgr.verticalPet);
        }
        else if(pet.player.isSwapPlayer == true)
        {
            pet.MovePet(GameManager.instance.Inputmgr.horizontal, GameManager.instance.Inputmgr.vertical);
        }


        if (pet.movement * pet.moveSpeed != new Vector3(0, 0, 0))
        {
            pet.ChangeState(normalState);
        }

        if (GameManager.instance.Inputmgr.runPet == 1)
        {
            pet.ChangeState(runState);
        }
    }
}
