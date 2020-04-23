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

        //if (Input.GetAxis("Horizontal") < -0.19 || Input.GetAxis("Horizontal") > 0.19 
        //    || Input.GetAxis("Vertical") < -0.19 || Input.GetAxis("Vertical") > 0.19 
        //    || Input.GetAxis("HorizontalPet") < -0.19 || Input.GetAxis("HorizontalPet") > 0.19 
        //    || Input.GetAxis("VerticalPet") < -0.19 || Input.GetAxis("VerticalPet") > 0.19)
        //    _graphic.SetActive(true);
        //else
        //    _graphic.SetActive(false);
        if (pc.movement * pc.moveSpeed != Vector3.zero)
            _graphic.SetActive(true);
        else
            _graphic.SetActive(false);

        transform.eulerAngles = new Vector3(0, Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * 180 / Mathf.PI, 0);
    }
}
