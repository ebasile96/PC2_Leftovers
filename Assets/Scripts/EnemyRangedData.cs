using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Ranged", menuName = "EnemyRanged")]
public class EnemyRangedData : ScriptableObject
{
    [SerializeField]
    public int speed;
    [SerializeField]
    public int angularSpeed;
    [SerializeField]
    public int acceleration;

}

