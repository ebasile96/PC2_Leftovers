﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetStay : PetStateBase
{
    PetController pet;
    PlayerController player;
    public override void Enter()
    {
        pet = GetComponent<PetController>();
        player = FindObjectOfType<PlayerController>();
    }

    public override void Tick()
    {
    
    }

    public override void Exit()
    {
        
    }
}
