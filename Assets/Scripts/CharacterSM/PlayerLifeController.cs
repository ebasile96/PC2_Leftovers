﻿using System.Collections;
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
    public GameObject hitPanel;

    //event 
    private Action DamageTakenCallBack;
    
    

    public void TakeDamage(float _damage)
    {
        healthPlayer -= _damage;
        DamageTakenCallBack();
    }

    public  void Update()
    {
        if (healthPlayer > 100)
            healthPlayer = 100;
    
        if(healthPlayer <= 25)
        {
            hitPanel.SetActive(true);
        }
        else if(healthPlayer > 25)
        {
            hitPanel.SetActive(false);
        }
    }

    public void DamageTakenCall(Action _damage)
    {
        DamageTakenCallBack = _damage;
    }

}
