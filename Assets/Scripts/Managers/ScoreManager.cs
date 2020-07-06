using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SemihOrhan.WaveOne.Spawners;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int Score;
    public float Timer;
    public int Bonus;
    public TextMeshProUGUI ScoreBoard;
    public TextMeshProUGUI HighscoreBoard;
    private IEnumerator _combo;
    public ChainController chainCtrl;
    public GameObject backgroundImageCombo;
    public GameObject comboText;
    public PlayerController player;
    Scene scene;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
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
                //animazione combo text
                //animazione score
                break;
            case EnemyType.shield:
                Score += 200 + Bonus;
                //animazione combo text
                //animazione score
                break;
            case EnemyType.damage:
                Score += 150 + Bonus;
                //animazione combo text
                //animazione score
                break;
            case EnemyType.bubble:
                Score += 200 + Bonus;
                //animazione combo text
                //animazione score
                break;
            case EnemyType.ranged:
                Score += 250 + Bonus;
                //animazione combo text
                //animazione score
                break;
        }

        PlayerPrefs.SetInt("PersonalScore", Score);

        if(Score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", Score);
            HighscoreBoard.text = Score.ToString();
        }
    }

    //private int compoMulti = 0;
    IEnumerator Combo(float _time)
    {
        Bonus = 100;
        if (scene.name == "BuildScene")
        {
            backgroundImageCombo.SetActive(true);
            comboText.SetActive(true);
        }
        GameObject vfxComboPlayer = Instantiate(GameManager.instance.Vfxmgr.vfxComboMode, player.transform);
        GameObject vfxComboPet = Instantiate(GameManager.instance.Vfxmgr.vfxComboMode, player.pet.transform);
        //moltiplicatoreCombo.text = "X" + compoMulti + 1;
        yield return new WaitForSeconds(_time);
        if (scene.name == "BuildScene")
        {
            backgroundImageCombo.SetActive(false);
            comboText.SetActive(false);
        }
        Bonus = 0;
        Destroy(vfxComboPlayer);
        Destroy(vfxComboPet);
    }
}
