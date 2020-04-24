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
        FlowStateMachine.GoToGameplay();
    }

    //momentaneo solo per far testare designer
    public void PressGDTest()
    {
       
    }

    public void PressBlu()
    {
        FlowStateMachine.GoToTestBlu();
    }

    public void PressGreen()
    {
        FlowStateMachine.GoToTestGreen();
    }

    public void PressRed()
    {
        FlowStateMachine.GotoTestRed();
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
