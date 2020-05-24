using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI score, highscore;

    private void Start()
    {
        score.text = PlayerPrefs.GetInt("PersonalScore", 0).ToString();
        highscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

}
