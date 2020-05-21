using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFeedback : MonoBehaviour
{
    public GameObject _graphic;
    public GameObject _graphicSwap;
    PlayerController pc;

    private void Start()
    {
        pc = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        if (pc.movement * pc.moveSpeed != Vector3.zero)
        {
            if (pc.isSwapPlayer == false)
            {
                transform.eulerAngles = new Vector3(0, Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * 180 / Mathf.PI, 0);
                _graphic.SetActive(true);
                _graphicSwap.SetActive(false);
            }
            else if (pc.isSwapPlayer == true)
            {
                transform.eulerAngles = new Vector3(0, Mathf.Atan2(Input.GetAxis("HorizontalPet"), Input.GetAxis("VerticalPet")) * 180 / Mathf.PI, 0);
                _graphic.SetActive(false);
                _graphicSwap.SetActive(true);
            }
        }
        else if (pc.movement * pc.moveSpeed == Vector3.zero)
        {
            _graphic.SetActive(false);
            _graphicSwap.SetActive(false);
        }
    }
}
