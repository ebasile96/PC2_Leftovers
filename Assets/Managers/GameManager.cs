using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //instances and setups
    public static GameManager instance = null;
    public InputManager Inputmgr;
    //variables
    public Agent currentAgent;
    public Player player;
    public Pet pet;

    void Awake()
    {
        
        Singleton();
        Inputmgr.Setup();
        player = FindObjectOfType<Player>();
        pet = FindObjectOfType<Pet>();
    }

    public void Singleton()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        currentAgent = player;
    }



}
