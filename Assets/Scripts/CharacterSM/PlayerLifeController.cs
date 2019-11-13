using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeController : MonoBehaviour
{
    public float healthPlayer;

    public void TakeDamage(float _damage)
    {
        healthPlayer -= _damage;
        if(healthPlayer <= 0)
        {
            //respawn player
        }
    }
}
