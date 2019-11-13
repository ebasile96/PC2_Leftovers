using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Agent
{
    public override void CheckInput()
    {
        forward = Input.GetAxis("Vertical");
        rotate = Input.GetAxis("Horizontal");
        dash = Input.GetKeyDown(KeyCode.LeftShift);
        attackMelee = Input.GetKeyDown(KeyCode.Space);
    }

    

}
