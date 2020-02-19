using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//momentaneo
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
   public void PressPlay()
    {
        GameManager.GoToGameplay();
    }

    //momentaneo solo per far testare designer
    public void PressGDTest()
    {
        SceneManager.LoadScene("GD Test");
    }

    //momentaneo solo per far testare 3D
    public void PressEnvTest()
    {
        SceneManager.LoadScene("giuliaENV");
    }

}
