using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

public class PlayerLifeController : MonoBehaviour
{
    public float healthPlayer;
    public float healthPet;
    public float damage;
    public Slider hpBarPlayer;
    //evento per la sovrascrizione dello score
    private Action DeathCallback;

    public void TakeDamage(float _damage)
    {
        healthPlayer -= _damage;
    }

    public  void Update()
    {
        if (healthPlayer > 100)
            healthPlayer = 100;
        if (healthPlayer <= 0)
            DeathCallback();
    }

    //callback allo score manager
    public void DeathCall(Action _death)
    {
        DeathCallback = _death;
    }
}
