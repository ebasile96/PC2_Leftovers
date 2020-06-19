using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [HideInInspector]
    public float runPlayer;
    [HideInInspector]
    public float runPet;
    [HideInInspector]
    public float horizontal;
    [HideInInspector]
    public float vertical;
    [HideInInspector]
    public float horizontalPet;
    [HideInInspector]
    public float verticalPet;
    [HideInInspector]
    public bool swapB1;
    [HideInInspector]
    public bool swapB2;

    public void CheckInput()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        verticalPet = Input.GetAxisRaw("VerticalPet");
        horizontalPet = Input.GetAxisRaw("HorizontalPet");
        runPlayer = Input.GetAxisRaw("runPlayer");
        runPet = Input.GetAxisRaw("runPet");
        swapB1 = Input.GetButtonDown("SwapB1");
        swapB2 = Input.GetButtonDown("SwapB2");
    }

    private void Update()
    {
        CheckInput();
    }
}
