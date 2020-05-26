using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHighScore : MonoBehaviour
{
    // Start is called before the first frame update

    public void Reset()
    {
        PlayerPrefs.SetInt("Highscore", 0);
    }

}
