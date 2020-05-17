using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SemihOrhan.WaveOne.Spawners;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int Score;
    public TextMeshProUGUI ScoreBoard;
    public TextMeshProUGUI HighscoreBoard;


    private void Start()
    {
        PlayerPrefs.SetInt("PersonalScore", 0);
        HighscoreBoard.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        
    }

    private void Update()
    {
        ScoreBoard.text = PlayerPrefs.GetInt("PersonalScore", 0).ToString();
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

        PlayerPrefs.SetInt("PersonalScore", Score);

        if(Score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", Score);
            HighscoreBoard.text = Score.ToString();
        }
    }
}
