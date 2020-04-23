using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFeedbackComp : MonoBehaviour
{
    public GameObject _graphic;
    PetController petc;

    private void Start()
    {
        petc = FindObjectOfType<PetController>();
    }

    private void Update()
    {
        if (petc.movement * petc.moveSpeed != Vector3.zero)
            _graphic.SetActive(true);
        else
            _graphic.SetActive(false);

        transform.eulerAngles = new Vector3(0, Mathf.Atan2(Input.GetAxis("HorizontalPet"), Input.GetAxis("VerticalPet")) * 180 / Mathf.PI, 0);
    }
}
