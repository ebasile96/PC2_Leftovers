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
        FlowStateMachine.GoToTutorial();
    }

    //momentaneo solo per far testare designer
    public void PressGDTest()
    {
       
    }

    public void PressBlu()
    {
        SceneManager.LoadScene("TestSceneRanged");
    }

    public void PressGreen()
    {
        SceneManager.LoadScene("TestSceneShield");
    }

    public void PressRed()
    {
        SceneManager.LoadScene("TestSceneBubble");
    }

    public void MainMenu()
    {
        FlowStateMachine.GoToMainMenu();
    }

    public void MenuPause()
    {
        //MEGA PROVVISORIO

        PauseMenuController pause = FindObjectOfType<PauseMenuController>();
        pause.pauseMenu.SetActive(false);
        Time.timeScale = 1;
        pause.isActive = false;
    }
}
