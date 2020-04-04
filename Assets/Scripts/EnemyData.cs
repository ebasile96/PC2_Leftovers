using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField]
    public int Life;
    [SerializeField]
    public int Damage;
    [SerializeField]
    public int rateoDamage;
    [SerializeField]
    public int Speed;

}
