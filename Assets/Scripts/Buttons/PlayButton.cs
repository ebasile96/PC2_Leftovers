using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//momentaneo
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayButton : MonoBehaviour
{
    public GameObject OptionsMenu;
    public GameObject Pausemenu;
    public GameObject credits;
    public GameObject newFirstSelected;
    public EventSystem eventSys;
   public void PressPlay()
    {
        if(PlayerPrefs.GetInt("Highscore") == 0)
        {
            FlowStateMachine.GoToTutorial();
        }
        else if(PlayerPrefs.GetInt("Highscore") > 0)
        {
            FlowStateMachine.GoToGameplay();
        }
        
    }

    public void Gameplay()
    {
        SceneManager.LoadScene("Buildscene");
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

    public void Tutorial()
    {
        FlowStateMachine.GoToTutorial();
    }

    public void MenuPause()
    {
        //MEGA PROVVISORIO

        PauseMenuController pause = FindObjectOfType<PauseMenuController>();
        pause.pauseMenu.SetActive(false);
        Time.timeScale = 1;
        pause.isActive = false;
    }

    public void openOptions()
    {
        OptionsMenu.SetActive(true);
        eventSys.firstSelectedGameObject = newFirstSelected;
        eventSys.SetSelectedGameObject(newFirstSelected);
        Pausemenu.SetActive(false);
        
    }

    public void OpenCredits()
    {
        credits.SetActive(true);
        Pausemenu.SetActive(false);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
    }
}
