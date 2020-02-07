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

    public void Start()
    {
        //hpBarPlayer = FindObjectOfType<Slider>();
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
            //carico scena gameover
            healthPlayer = 3;
        }
    }
}
