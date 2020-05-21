using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFeedbackComp : MonoBehaviour
{
    public GameObject _graphic;
    public GameObject _graphicSwap;
    PetController petc;
    public PlayerController player;

    private void Start()
    {
        petc = FindObjectOfType<PetController>();
    }

    private void Update()
    {
        if (petc.movement * petc.moveSpeed != Vector3.zero)
        {
            if (player.isSwapPlayer == false)
            {
                transform.eulerAngles = new Vector3(0, Mathf.Atan2(Input.GetAxis("HorizontalPet"), Input.GetAxis("VerticalPet")) * 180 / Mathf.PI, 0);
                _graphic.SetActive(true);
                _graphicSwap.SetActive(false);
            }
            else if (player.isSwapPlayer == true)
            {
                transform.eulerAngles = new Vector3(0, Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * 180 / Mathf.PI, 0);
                _graphic.SetActive(false);
                _graphicSwap.SetActive(true);
            }
        }
        else if (petc.movement * petc.moveSpeed == Vector3.zero)
        {
            _graphic.SetActive(false);
            _graphicSwap.SetActive(false);
        }
    }


}
