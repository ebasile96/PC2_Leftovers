using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    //levelData
    
    public int WavesNumber;
    public float WaveTimer;
    public bool WaveEnded;

    //setup con i data che riempiranno tutte le variabili in maniera corretta avviato da levelMgr
    //evento da inviare al LvlMgr per far finire il livello quando tutte le ondate son finite
}
