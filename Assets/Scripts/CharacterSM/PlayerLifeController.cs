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
    
    

    public void TakeDamage(float _damage)
    {
        healthPlayer -= _damage;
    }

    public  void Update()
    {
        if (healthPlayer > 100)
            healthPlayer = 100;
    
    }

    

}
