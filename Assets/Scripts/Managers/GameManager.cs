using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SemihOrhan.WaveOne;

public class GameManager : MonoBehaviour
{
    //instances and setups
    public static GameManager instance = null;
    //managers
    public InputManager Inputmgr;
    public UIManager UImgr;
    public WaveManager Wavemgr;
    public LevelManager Levelmgr;
    public VFXManager Vfxmgr;
    void Awake()
    {
        Singleton();
        InitManagers();
    }

    public void InitManagers()
    {
        GetInputMgr();
        GetUImgr();
        GetWavemgr();
        GetLevelMgr();
        GetVfxMgr();
    }


    public void Singleton()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
    }

    #region Getter

    public InputManager GetInputMgr()
    {
        if (!Inputmgr)
        {
            Inputmgr = FindObjectOfType<InputManager>();
        }

        return Inputmgr;
    }

    public UIManager GetUImgr()
    {
        if (!UImgr)
        {
            UImgr = FindObjectOfType<UIManager>();
        }

        return UImgr;
    }

    public WaveManager GetWavemgr()
    {
        if (!Wavemgr)
        {
            Wavemgr = FindObjectOfType<WaveManager>();
        }
        return Wavemgr;
    }

    public LevelManager GetLevelMgr()
    {
        if (!Levelmgr)
        {
            Levelmgr = FindObjectOfType<LevelManager>();
        }
        return Levelmgr;
    }
    #endregion

    public VFXManager GetVfxMgr()
    {
        if (!Vfxmgr)
        {
            Vfxmgr = FindObjectOfType<VFXManager>();
        }
        return Vfxmgr;
    }
}
