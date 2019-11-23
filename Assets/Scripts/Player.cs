using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Agent
{
    public override void CheckInput()
    {
        forward = Input.GetAxis("Vertical");
        rotate = Input.GetAxis("Horizontal");
        dash = Input.GetKeyDown(KeyCode.Space);
        attackMelee = Input.GetKeyDown(KeyCode.J);
        stayHere = Input.GetKey(KeyCode.L);
        follow = Input.GetKey(KeyCode.I);
        shootPet = Input.GetKeyDown(KeyCode.K);
    }

    

}
