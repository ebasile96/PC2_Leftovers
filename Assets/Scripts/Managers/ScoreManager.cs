using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SemihOrhan.WaveOne.Spawners;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int Score;
    public Text ScoreBoard;


    private void Start()
    {
       
       
    }

    private void Update()
    {
        ScoreBoard.text = Score.ToString();
    }
    public void PointAssignation(EnemyType _type)
    {
        switch (_type)
        {
            case EnemyType.green:
                Score += 100;
                break;
            case EnemyType.blue:
                Score += 150;
                break;
            case EnemyType.shield:
                Score += 200;
                break;
            case EnemyType.damage:
                Score += 150;
                break;
            case EnemyType.bubble:
                Score += 200;
                break;
            case EnemyType.ranged:
                Score += 250;
                break;
        }
    }
}
