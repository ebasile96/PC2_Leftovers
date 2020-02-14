﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetNormalState : PetStateBase
{
    public PetStateBase idleState;

    public override void Tick()
    {
        pet.MovePet();
        pet.animator.SetTrigger("GoToRunning");
        if (pet.movement * pet.moveSpeed == new Vector3(0, 0, 0))
        {
            pet.ChangeState(idleState);
        }
    }
}
