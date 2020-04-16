using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SemihOrhan.WaveOne;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> EnemiesAlive = new List<GameObject>();
    private WaveManager Wavemgr;
    public Text EnemyAlive;
    public Text WaveNumber;
    [Range(0,100)]
    public int HealthBonus = 20;
    int wavecount = 1;
    PlayerLifeController playerLifeCtrl;
    // Start is called before the first frame update
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
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Life: " + playerLifeCtrl.healthPlayer);
        EnemyAlive.text = "Enemies Left: " + EnemiesAlive.Count;
        WaveNumber.text = "Wave " + wavecount;
        //Debug.Log("enemiesAlive: " + EnemiesAlive.Count);
        FindEnemies();
        if(Wavemgr.SpawnersFinished && EnemiesAlive.Count == 0)
        {
            CheckLifeBonus();
            wavecount++;
            Wavemgr.StartAllConfigWaves();
        }

    }

    public void FindEnemies()
    {
        foreach (GameObject _enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if(!EnemiesAlive.Contains(_enemy))
                EnemiesAlive.Add(_enemy);

        }
    }

    public void CheckLifeBonus()
    {
        if(playerLifeCtrl.healthPlayer < 100)
        {
            playerLifeCtrl.healthPlayer += HealthBonus;
        }

    }
}
