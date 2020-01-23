using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetNormalState : PetStateBase
{
    public override void Tick()
    {
        pet.MovePet();
        pet.RotationPet();
    }
}
