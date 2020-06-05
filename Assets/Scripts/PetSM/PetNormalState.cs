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
    }

    public override void Tick()
    {
      
        
        pet.MovePet(GameManager.instance.Inputmgr.horizontalPet, GameManager.instance.Inputmgr.verticalPet);
        
        pet.animator.SetTrigger("GoToRunning");
        if (pet.movement * pet.moveSpeed == new Vector3(0, 0, 0))
        {
            pet.ChangeState(idleState);
        }

        //if (GameManager.instance.Inputmgr.runPet == 1)
        //{
        //  pet.ChangeState(runState);
        //}


            pet.RunControllPet(GameManager.instance.Inputmgr.runPet, runState);
        

    }
}
