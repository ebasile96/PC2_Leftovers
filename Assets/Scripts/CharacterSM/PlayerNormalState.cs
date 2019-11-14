using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalState : PlayerBaseState
{
    public PlayerBaseState dashState;

    public override void Tick()
    {
        player.Move();
        player.Rotate();
        
        
    }

}
