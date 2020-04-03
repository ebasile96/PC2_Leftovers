using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MMButton : MonoBehaviour
{
    public void BackToMainMenu()
    {
        FlowStateMachine.GoToMainMenu();
    }
}
