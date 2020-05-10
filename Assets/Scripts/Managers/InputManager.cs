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

    public void CheckInput()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        verticalPet = Input.GetAxisRaw("VerticalPet");
        horizontalPet = Input.GetAxisRaw("HorizontalPet");
        runPlayer = Input.GetAxisRaw("runPlayer");
        runPet = Input.GetAxisRaw("runPet");
    }

    private void Update()
    {
        CheckInput();
    }
}
