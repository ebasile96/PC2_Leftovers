using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tesshader : MonoBehaviour
{
    public Material shader;
    public IEnumerator Dissolve(Material _shader, float _startValue, float _delta)
    {
        float pointInTime = 0f;
        float dissolveTime = 3f;
        while (pointInTime <= dissolveTime)
        {
            _shader.SetFloat("_dissolveIntensity", Mathf.Lerp(_startValue, _delta, pointInTime / dissolveTime));
            pointInTime += Time.deltaTime;
            yield return 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           StartCoroutine(Dissolve(shader, 0, 1));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Dissolve(shader, 1, 0));
        }

    }
}
