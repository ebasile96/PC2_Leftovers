using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFeedback : MonoBehaviour
{
    public GameObject _graphic;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
            _graphic.SetActive(true);
        else
            _graphic.SetActive(false);

        transform.eulerAngles = new Vector3(0, Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * 180 / Mathf.PI, 0);
    }
}
