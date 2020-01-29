using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetIdleState : PetStateBase
{
    public PetStateBase normalState;

    public override void Tick()
    {
        pet.animator.SetTrigger("GoToIdle");
        pet.MovePet();
        if (pet.moveDirection * pet.speed != new Vector3(0, 0, 0))
        {
            pet.ChangeState(normalState);
        }
    }
}
