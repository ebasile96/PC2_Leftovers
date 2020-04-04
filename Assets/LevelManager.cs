using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SemihOrhan.WaveOne;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> EnemiesAlive = new List<GameObject>();
    private WaveManager Wavemgr;
    public Text Timertext;
    float startingTimer = 0f;
    [Tooltip("Ricordate che il timer parte da quando è spawnato l'ultimo enemy dell'ondata")]
    public float Timer;
    // Start is called before the first frame update
    void Awake()
    {
        Wavemgr = FindObjectOfType<WaveManager>();
    }

    private void Start()
    {
        if (!Wavemgr.SpawnersFinished)
            Wavemgr.StartAllConfigWaves();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("enemiesAlive: " + EnemiesAlive.Count);
        FindEnemies();
        Timertext.text = ("Timer: " + Mathf.Round(startingTimer));
        //Debug.Log("spawnerStarted: " + Wavemgr.SpawnersStarted);
        //Debug.Log("spawnerFinished: " + Wavemgr.SpawnersFinished);
        if(Wavemgr.SpawnersFinished && EnemiesAlive.Count == 0)
        {
            //startingTimer += Time.deltaTime;

            //if (startingTimer > 3)
            //{
            //    Wavemgr.StartAllConfigWaves();
            //}
            //startingTimer = 0f;
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
}
