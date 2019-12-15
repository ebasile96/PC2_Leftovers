using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject MainMenu, Pause, HUD;
    public GameObject CurrentPanel;

    private void Awake()
    {
        if (CurrentPanel == null)
        {
            CurrentPanel = MainMenu;
        }
    }

    public void ActivatePanel(GameObject _gobj)
    {
        _gobj.SetActive(true);
        CurrentPanel = _gobj;
    }

    public void DeactivatePanel(GameObject _gobj)
    {
        if (_gobj != null)
            _gobj.SetActive(false);
    }

    public void ChangePanel(UItype _UItype)
    {
        if (CurrentPanel != null)
        {
            switch (_UItype)
            {
                case UItype.MainMenu:
                    CurrentPanel = MainMenu;
                    break;
                case UItype.Pause:
                    CurrentPanel = Pause;
                    break;
                case UItype.HUD:
                    CurrentPanel = HUD;
                    break;
               
            }
        }
        else
        {
            Debug.LogWarning("CurrentPanel empty");
        }
    }

    public enum UItype
    {
        MainMenu, 
        Pause, 
        HUD
    }
}
