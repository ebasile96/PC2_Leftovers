using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SemihOrhan.WaveOne;

public class LevelManager : MonoBehaviour
{
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
        Timertext.text = ("Timer: " + Mathf.Round(startingTimer));
        //Debug.Log("spawnerStarted: " + Wavemgr.SpawnersStarted);
        //Debug.Log("spawnerFinished: " + Wavemgr.SpawnersFinished);
        if(Wavemgr.SpawnersFinished)
        {
            startingTimer += Time.deltaTime;
            
            if (startingTimer > 3)
            {
                Wavemgr.StartAllConfigWaves();
            }
            startingTimer = 0f;
        }
    }
}
