using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreditsButton : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject newFirstSelected;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Escape))
            ExitMenu();
    }

    public void ExitMenu()
    {
        pauseMenu.SetActive(true);
        eventSystem.firstSelectedGameObject = newFirstSelected;
        eventSystem.SetSelectedGameObject(newFirstSelected);
        this.gameObject.SetActive(false);

    }
}
