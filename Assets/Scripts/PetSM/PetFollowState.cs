using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetFollowState : PetStateBase
{
    public PetController controller;

    
    public override void Enter()
    {
        
    }

    public override void Tick()
    {
        
        controller.Follow();
        
    }

    public override void Exit()
    {
        
    }
}
