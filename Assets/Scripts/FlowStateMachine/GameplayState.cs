using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SemihOrhan.WaveOne;
using SemihOrhan.WaveOne.Spawners;
using SemihOrhan.WaveOne.Demo;

public class GameplayState : StateBehaviourBase
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneManager.LoadScene("BuildScene");
        GameManager.instance.InitManagers();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if (Input.GetKeyDown(KeyCode.W))
        //    GameManager.instance.Wavemgr.StartAllConfigWaves();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
