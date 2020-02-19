﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarController : MonoBehaviour
{
    public PlayerLifeController playerLife;
    public PlayerLifeController petLife;
    public float healthLenght;
    public float weakSpell = 0.1f;
    public GameObject healthbar;

    // Start is called before the first frame update
    void Start()
    {
        //playerLife = GetComponent<PlayerLifeController>();
    }

    // Update is called once per frame
    void Update()
    {
        healthLenght = playerLife.healthPlayer;
        healthbar.GetComponent<RectTransform>().sizeDelta = new Vector2(healthLenght, 100);
    }
}
