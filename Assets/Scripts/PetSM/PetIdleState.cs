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
    }

    public override void Tick()
    {
        pet.animator.SetTrigger("GoToIdle");

        pet.MovePet(GameManager.instance.Inputmgr.horizontalPet, GameManager.instance.Inputmgr.verticalPet);

        if (pet.movement * pet.moveSpeed != new Vector3(0, 0, 0))
        {
            pet.ChangeState(normalState);
        }

        //if (GameManager.instance.Inputmgr.runPet == 1)
        //{
        //  pet.ChangeState(runState);
        //}

            pet.RunControllPet(GameManager.instance.Inputmgr.runPet, runState);
    }
}
