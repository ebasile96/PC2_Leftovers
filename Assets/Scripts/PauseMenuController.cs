using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    //PROVVISORIO

    public bool isActive;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ActiveDisactivePauseMenu();
    }

    private void ActiveDisactivePauseMenu()
    {
        if (Input.GetButtonDown("Pause") && isActive == false)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isActive = true;
        }
        else if(Input.GetButtonDown("Pause") && isActive == true)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            isActive = false;
        }
    }


}
