using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SemihOrhan.WaveOne;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    //instances and setups
    public static GameManager instance = null;
    public Context newContext;
    public Animator animController;
    //managers
    public InputManager Inputmgr;
    public UIManager UImgr;
    public WaveManager Wavemgr;
    void Awake()
    {
        Singleton();
        SetUpSM();
        InitManagers();
    }

    private void OnEnable()
    {
        if(instance == this)
        {
            GoToMainMenu += instance.HandleOnMainMenu;
            GoToPause += instance.HandleOnPause;
            GoToGameplay += instance.HandleOnGameplay;
        }
    }

    public void InitManagers()
    {
        GetInputMgr();
        GetUImgr();
        GetWavemgr();
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


    public UIManager GetUImgr()
    {
        if (!UImgr)
        {
            return UImgr;
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
    #endregion

    #region SM

    public class Context { }

    void SetUpSM()
    {
        //Setup della state machine e del context
        animController = GetComponent<Animator>();
        
        Context context = new Context()
        {
            
        };
        foreach (StateBehaviourBase state in animController.GetBehaviours<StateBehaviourBase>())
        {
            state.Setup(context);
        }
    }

    //Delegates
    public static Action GoToMainMenu;
    public static Action GoToPause;
    public static Action GoToGameplay;

    //events
    private void HandleOnMainMenu()
    {
        animController.SetTrigger("GoToMainMenu");
    }

    private void HandleOnGameplay()
    {
        animController.SetTrigger("GoToGameplay");
    }

    private void HandleOnPause()
    {
        animController.SetTrigger("GoToPause");
    }
    #endregion

    private void OnDisable()
    {
        if (instance == this)
        {
            GoToMainMenu -= instance.HandleOnMainMenu;
            GoToPause -= instance.HandleOnPause;
            GoToGameplay -= instance.HandleOnGameplay;
        }
    }
}
