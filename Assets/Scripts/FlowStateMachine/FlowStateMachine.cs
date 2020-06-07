using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class FlowStateMachine : MonoBehaviour
{
    public Context newContext;
    public Animator animController;
    public static float VolumeMaster;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("StateMachine");
        if(objs.Length > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        SetUpSM();
    }

    private void OnEnable()
    {
        GoToMainMenu += HandleOnMainMenu;
        GoToPause += HandleOnPause;
        GoToGameplay += HandleOnGameplay;
        GoToTestBlu += HandleOnTestBlu;
        GoToTestGreen += HandleOnTestGreen;
        GotoTestRed += HandleOnTestRed;
        GoToTutorial += HandleOnTutorial;
        GoToWin += HandleOnWin;
        GoToLose += HandleOnLose;
    }
    #region Setup

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

    #endregion
    #region delegates

    public static Action GoToMainMenu;
    public static Action GoToPause;
    public static Action GoToGameplay;
    public static Action GoToTestBlu;
    public static Action GotoTestRed;
    public static Action GoToTestGreen;
    public static Action GoToTutorial;
    public static Action GoToWin;
    public static Action GoToLose;

    #endregion

    #region events
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

    private void HandleOnTestBlu()
    {
        animController.SetTrigger("GoToTestBlu");
    }

    private void HandleOnTestRed()
    {
        animController.SetTrigger("GoToTestRed");
    }

    private void HandleOnTestGreen()
    {
        animController.SetTrigger("GoToTestGreen");
    }

    private void HandleOnTutorial()
    {
        animController.SetTrigger("GoToTutorial");
    }

    private void HandleOnWin()
    {
        animController.SetTrigger("GoToWin");
    }

    private void HandleOnLose()
    {
        animController.SetTrigger("GoToLose");
    }
    #endregion
    private void OnDisable()
    {
        GoToMainMenu -= HandleOnMainMenu;
        GoToPause -= HandleOnPause;
        GoToGameplay -= HandleOnGameplay;
        GoToTestBlu -= HandleOnTestBlu;
        GoToTestGreen -= HandleOnTestGreen;
        GotoTestRed -= HandleOnTestRed;
        GoToTutorial -= HandleOnTutorial;
        GoToWin -= HandleOnWin;
        GoToLose -= HandleOnLose;
    }
}
