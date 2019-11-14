using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeController : MonoBehaviour
{
    public float healthPlayer;
    public float damage;

    public void TakeDamage(float _damage)
    {
        healthPlayer -= _damage;
    }

    private void Update()
    {
        if (healthPlayer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
