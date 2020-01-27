using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName ="NewWave")]
public class WaveData : ScriptableObject
{
    public List<GameObject> EnemyModule = new List<GameObject>();
}
