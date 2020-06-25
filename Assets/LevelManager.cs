using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SemihOrhan.WaveOne;
using TMPro;
using System;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> EnemiesAlive = new List<GameObject>();
    private WaveManager Wavemgr;
    public TextMeshProUGUI EnemyAlive;
    public TextMeshProUGUI WaveNumber;
    public GameObject totalWaveNumberUI;
    [Range(0,100)]
    public int HealthBonus = 20;
    int wavecount = 1;
    PlayerLifeController playerLifeCtrl;
    public int _EnemyCounterAlive = 0;
    public PlayerController player;
    public PetController pet;
    // Start is called before the first frame update

    //event
    private Action StartWaveCallback;
    void Awake()
    {
        Wavemgr = FindObjectOfType<WaveManager>();
        playerLifeCtrl = FindObjectOfType<PlayerLifeController>();
    }

    private void Start()
    {
        if (!Wavemgr.SpawnersFinished)
        {
            Wavemgr.StartAllConfigWaves();
            StartWaveCallback();
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        EnemyAlive.text = "" + _EnemyCounterAlive;
        WaveNumber.text = "" + wavecount;
        if(Wavemgr.SpawnersFinished && _EnemyCounterAlive == 0)
        {
            CheckLifeBonus();
            wavecount++;
            Wavemgr.StartAllConfigWaves();
            StartWaveCallback();
            WaveNumber.GetComponent<Animator>().SetTrigger("active");
            totalWaveNumberUI.GetComponent<Animator>().SetTrigger("active");
            WaveNumber.GetComponent<Animator>().SetTrigger("idle");
            totalWaveNumberUI.GetComponent<Animator>().SetTrigger("idle");
        }
    }

    //public void FindEnemies()
    //{
    //    foreach (GameObject _enemy in GameObject.FindGameObjectsWithTag("Enemy"))
    //    {
    //        if(!EnemiesAlive.Contains(_enemy))
    //            EnemiesAlive.Add(_enemy);

    //    }
    //}

    public void CheckLifeBonus()
    {
        if(playerLifeCtrl.healthPlayer < 100)
        {
            playerLifeCtrl.healthPlayer += HealthBonus;
            Instantiate(GameManager.instance.Vfxmgr.vfxHealPlayer, player.transform);
            Instantiate(GameManager.instance.Vfxmgr.vfxHealPlayer, pet.transform);
        }

    }

    public void StartWaveCall(Action _start)
    {
        StartWaveCallback = _start;
    }
}
