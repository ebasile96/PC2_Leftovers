using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodMode : MonoBehaviour
{
    PlayerLifeController lifeCtrl;
    public Button OnButton;
    public Button OffButton;

    private void Start()
    {
        lifeCtrl = FindObjectOfType<PlayerLifeController>();
    }
    private void Update()
    {
        if (OnButton.interactable == false)
        {
            if (lifeCtrl.healthPlayer < 100)
                lifeCtrl.healthPlayer = 100;
        }

    }

    public void GodModeON()
    {
        OnButton.interactable = false;
        OffButton.interactable = true;
    }

    public void GodModeOFF()
    {
        OnButton.interactable = true;
        OffButton.interactable = false;
    }
}
