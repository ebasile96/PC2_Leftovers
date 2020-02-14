using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [HideInInspector]
    public bool dash;
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
        dash = Input.GetKeyDown(KeyCode.Space);
    }

    private void Update()
    {
        CheckInput();
    }
}
