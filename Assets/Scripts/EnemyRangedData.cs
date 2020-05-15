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
    [SerializeField]
    public Transform[] points;
    [SerializeField]
    public float maxTimerAttack;
    [SerializeField]
    public int damageArrow;
    [SerializeField]
    public GameObject projectile;
    [SerializeField]
    public float speedProjectile;
    [SerializeField]
    public float damagePhysic;
    [SerializeField]
    public float rateoDamagePhysic;
}
