using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SemihOrhan.WaveOne;

public class LevelManager : MonoBehaviour
{
    public WaveManager Wavemgr;
    // Start is called before the first frame update
    void Awake()
    {
        Wavemgr = FindObjectOfType<WaveManager>();
    }

    private void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!Wavemgr.SpawnersStarted)
        {
            Wavemgr.StartAllConfigWaves();
        }
        //OVVIAMENTE DA RIFARE PD
        if (Wavemgr.AmountSpawnersFinished == 2)
            Wavemgr.StartAllConfigWaves();
        Debug.Log("spawner finished " + Wavemgr.SpawnersFinished);
        Debug.Log("spawner started " + Wavemgr.SpawnersStarted);
        Debug.Log("amount finished " + Wavemgr.AmountSpawnersFinished);


        
    }
}
