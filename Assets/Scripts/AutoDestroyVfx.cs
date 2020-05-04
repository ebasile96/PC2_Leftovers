using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AutoDestroyVfx : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 1);
    }
}
