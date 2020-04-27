using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : RangedStateBehaviour
{
    public RangedStateBehaviour movementState;
    public override void Enter()
    {
      
    }

    public override void Tick()
    {
        ranged.ChangeState(movementState);
    }

    public override void Exit()
    {
        
    }
}
