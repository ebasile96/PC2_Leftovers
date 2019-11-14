using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Player player;
    Pet pet;
    
    private void Awake()
    {
        Setup();
    }
    /// <summary>
    /// funzione che cambia in base al currentAgent in gm
    /// controllo su gamemanager dell current Agent
    /// agent = currentagent
    /// </summary>
    /// <param name="agent"></param>
    
    public void Setup()
    {
        player = FindObjectOfType<Player>();
        pet = FindObjectOfType<Pet>();
        
    }

    void Update()
    {
        CheckInput(GameManager.instance.currentAgent); 
    }
    public void CheckInput(Agent agent)
    {
        agent = GameManager.instance.currentAgent;
        agent.CheckInput();
    }
    
    /// <summary>
    /// switch in base al currentagent
    /// </summary>
    /// <param name="input"></param>
    public void SwitchInput(Input input)
    {
        switch (input)
        {
            case Input.player:
                CheckInput(GameManager.instance.currentAgent);
                
                break;
            case Input.pet:
                break;
            default:
                break;
        }
    }
public enum Input
    {
        player, 
        pet
    }
}
