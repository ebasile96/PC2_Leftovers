using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFeedback : MonoBehaviour
{
    public GameObject _graphic;
    PlayerController pc;

    private void Start()
    {
        pc = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        if (pc.movement * pc.moveSpeed != Vector3.zero)
        {
                transform.eulerAngles = new Vector3(0, Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * 180 / Mathf.PI, 0);
                _graphic.SetActive(true);
        }
        else 
        {
            _graphic.SetActive(false);
        }
    }
}
