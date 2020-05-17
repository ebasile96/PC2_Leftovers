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
    public float Timer;
    public int Bonus;
    public TextMeshProUGUI ScoreBoard;
    public TextMeshProUGUI HighscoreBoard;
    private IEnumerator _combo;
    public ChainController chainCtrl;
    private void Start()
    {
        PlayerPrefs.SetInt("PersonalScore", 0);
        HighscoreBoard.text = PlayerPrefs.GetInt("Highscore", 0).ToString();

        chainCtrl.KillCall(() =>
        {
            if (_combo != null)
                StartCoroutine(_combo);
            _combo = Combo(Timer);
            StartCoroutine(_combo);
        });
    }

    private void Update()
    {
        Debug.Log(Bonus);
        ScoreBoard.text = PlayerPrefs.GetInt("PersonalScore", 0).ToString();
    }
    public void PointAssignation(EnemyType _type)
    {
        switch (_type)
        {
            case EnemyType.green:
                Score += 100 + Bonus;
                break;
            case EnemyType.blue:
                Score += 150 + Bonus;
                break;
            case EnemyType.shield:
                Score += 200 + Bonus;
                break;
            case EnemyType.damage:
                Score += 150 + Bonus;
                break;
            case EnemyType.bubble:
                Score += 200 + Bonus;
                break;
            case EnemyType.ranged:
                Score += 250 + Bonus;
                break;
        }

        PlayerPrefs.SetInt("PersonalScore", Score);

        if(Score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", Score);
            HighscoreBoard.text = Score.ToString();
        }
    }

    IEnumerator Combo(float _time)
    {
        Bonus = 100; 
        yield return new WaitForSeconds(_time);
        Bonus = 0;
    }
}
