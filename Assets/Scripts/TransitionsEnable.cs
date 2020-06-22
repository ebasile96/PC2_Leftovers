using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionsEnable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DisactiveObject());
    }

    public IEnumerator DisactiveObject()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
