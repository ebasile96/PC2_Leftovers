using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalState : PlayerBaseState
{
    public PlayerBaseState dashState;
    public override void Tick(PlayerController.InputData data)
    {
        // logica
        //player.targetForward = Mathf.Lerp(player.targetForward, data.forward, Time.deltaTime * 4);
        player.Move();
        //player.Rotate(data.rotate);
        //player.UpdatePositionAndRotation();

        /*if (data.attackMelee)
        {

        }*/
        
        
    }

}
