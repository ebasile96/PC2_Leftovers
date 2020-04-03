using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthController : MonoBehaviour
{
    public List<Agent> Characters = new List<Agent>();
    Player player;
    Pet pet;
    public int Life = 10;

    void Start()
    {
        Setup();
    }

    void Update()
    {
        CheckLife();
    }

    public void Setup()
    {
        FindAgents();
    }

    public void FindAgents()
    {
        player = FindObjectOfType<Player>();
        pet = FindObjectOfType<Pet>();

        if(player != null && pet != null)
        {
            Characters.Add(player);
            Characters.Add(pet);
        }
    }

    public void CheckLife()
    {
        if(Life <= 0)
        {
            FlowStateMachine.GoToMainMenu();
        }
    }


}
