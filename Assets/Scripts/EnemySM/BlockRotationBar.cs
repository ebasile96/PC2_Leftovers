using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotationBar : MonoBehaviour
{
    Quaternion rotation;
    public Transform cameraPosition;

    // Start is called before the first frame update
    void Awake()
    {
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = rotation;
    }
}
