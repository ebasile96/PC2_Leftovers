using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public PlayerController playerCtrl;
    public float health;
    public GameObject doorEnemy;

    public void Start()
    {
        playerCtrl = FindObjectOfType<PlayerController>();
    }

    public void TakeDamage(float _damage)
    {
        health -= _damage;
        /*if(health <= 0f)
        {
            this.gameObject.SetActive(false);
            playerCtrl.isShieldEnemy = true;
            doorEnemy.SetActive(false);
        }*/
    }

    private void Update()
    {
        if (health <= 0f)
        {
            this.gameObject.SetActive(false);
            playerCtrl.isShieldEnemy = true;
            doorEnemy.SetActive(false);
        }
    }
}
