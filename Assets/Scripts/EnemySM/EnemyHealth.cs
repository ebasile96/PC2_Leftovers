using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public PlayerController playerCtrl;
    public float health;
    public GameObject doorEnemy;
    public Slider hpBarEnemy;
    public Transform cameraPosition;

    public void Start()
    {
        playerCtrl = FindObjectOfType<PlayerController>();
        //hpBarEnemy = FindObjectOfType<Slider>();
        cameraPosition = GetComponent<Transform>();
    }

    public void TakeDamage(float _damage)
    {
        health -= _damage;
    }

    private void Update()
    {
        hpBarEnemy.value = health;

        if (health <= 0f)
        {
            this.gameObject.SetActive(false);

        }
    }
}
