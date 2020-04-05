using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//momentaneo
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
   public void PressPlay()
    {
        FlowStateMachine.GoToGameplay();
    }

    //momentaneo solo per far testare designer
    public void PressGDTest()
    {
        SceneManager.LoadScene("BuildScene(TestChainGabri)");
    }

    public void PressBlu()
    {
        FlowStateMachine.GoToTestBlu();
    }

    public void PressGreen()
    {
        FlowStateMachine.GoToTestGreen();
    }

    public void PressRed()
    {
        FlowStateMachine.GotoTestRed();
    }
}
