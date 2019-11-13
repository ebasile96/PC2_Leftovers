using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform PlayerTransform;
    Vector3 v;

    void Start()
    {
        v = transform.position - PlayerTransform.position;
    }
    void Update()
    {
        if (PlayerTransform != null)
        {
            transform.position = PlayerTransform.position + v;
        }
    }

    }
