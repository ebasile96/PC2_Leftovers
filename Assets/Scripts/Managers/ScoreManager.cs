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
    [SerializeField]private PlayerLifeController playerCtrl;
    [SerializeField]private PerWaveCustom waveConfig;

    private void Start()
    {
        PlayerPrefs.SetInt("CurrentScore", 0);
        playerCtrl.DeathCall(() => { PlayerPrefs.SetInt("CurrentScore", Score); if (Score > PlayerPrefs.GetInt("Highscore", 0)) { PlayerPrefs.SetInt("Highscore", Score); } });
        waveConfig.WinCall(() => { PlayerPrefs.SetInt("CurrentScore", Score); if (Score > PlayerPrefs.GetInt("Highscore", 0)) { PlayerPrefs.SetInt("Highscore", Score); } });
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
