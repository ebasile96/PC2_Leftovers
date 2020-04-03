﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class FlowStateMachine : MonoBehaviour
{
    public Context newContext;
    public Animator animController;
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
    #endregion
    private void OnDisable()
    {
        GoToMainMenu -= HandleOnMainMenu;
        GoToPause -= HandleOnPause;
        GoToGameplay -= HandleOnGameplay;
    }
}
