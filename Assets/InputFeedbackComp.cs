using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFeedbackComp : MonoBehaviour
{
    public GameObject _graphic;

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            _graphic.SetActive(true);
        else
            _graphic.SetActive(false);

        transform.eulerAngles = new Vector3(0, Mathf.Atan2(Input.GetAxis("HorizontalPet"), Input.GetAxis("VerticalPet")) * 180 / Mathf.PI, 0);
    }
}
