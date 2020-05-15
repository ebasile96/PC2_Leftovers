using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField]
    public int Life;
    [SerializeField]
    public int damage;
    [SerializeField]
    public int rateoDamage;
    [SerializeField]
    public int speed;
    [SerializeField]
    public int angularSpeed;
    [SerializeField]
    public int acceleration;
    [SerializeField]
    public int damageShield;
    [SerializeField]
    public float TimerBubble;
    [SerializeField]
    public EnemyType Type;

}

public enum EnemyType
{
    green,
    blue,
    shield,
    damage,
    bubble,
    ranged
}
