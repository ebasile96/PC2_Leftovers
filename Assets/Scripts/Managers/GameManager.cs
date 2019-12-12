using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //instances and setups
    public static GameManager instance = null;

    public InputManager Inputmgr;
    void Awake()
    {
        
        Singleton();
        InitManagers();
    }

    public void InitManagers()
    {
        GetInputMgr();
    }


    public void Singleton()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    #region Getter

    public InputManager GetInputMgr()
    {
        if (!Inputmgr)
        {
            return Inputmgr;
        }

        return Inputmgr;
    }

    #endregion




}
