using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerLifeController : MonoBehaviour
{
    public float healthPlayer;
    public float damage;
    public Slider hpBarPlayer;
    public Transform positionPlayer;
    public Transform respawnPlayer;
    public Transform respawnPet;
    public Transform petPosition;

    public void Start()
    {
        //hpBarPlayer = FindObjectOfType<Slider>();
        positionPlayer = GetComponent<Transform>();
        respawnPlayer = GetComponent<Transform>();
        petPosition = GetComponent<Transform>();
        respawnPet = GetComponent<Transform>();
    }

    public void TakeDamage(float _damage)
    {
        healthPlayer -= _damage;
    }

    public  void Update()
    {
        hpBarPlayer.value = healthPlayer;

        if (healthPlayer <= 0)
        {
            positionPlayer.position += respawnPlayer.position;
            petPosition.position = respawnPet.position;
            healthPlayer = 3;
        }
    }
}
