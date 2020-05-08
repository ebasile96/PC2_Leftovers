using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainGraphic : MonoBehaviour
{
    public LineRenderer lineR;
    public Transform targetLine;
    public float dstToTarget;
    public float maxLenghtChain;
    public Vector3 dirToTarget;
    public ChainController chainController;

    //grafica catena 
    public Material lightMaterial;
    public Material mediumMaterial;
    public Material heavyMaterial;
    public Material neutralMaterial;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetLineRender();
        SetGraphicValue();
    }

    private void SetLineRender()
    {
        dirToTarget = (targetLine.position - transform.position).normalized;
        dstToTarget = Vector3.Distance(transform.position, targetLine.position);
        if (dstToTarget < maxLenghtChain && lineR.enabled == true)
        {
            //lineR.enabled = true;
            lineR.SetPosition(0, transform.position);
            lineR.SetPosition(1, targetLine.position);
        }
        else
        {
            ChainGraphicBreaker();
            //lineR.enabled = false;
            //chainController.currentStressValue = 100;
        }
    }

    public void ChainGraphicBreaker()
    {
        lineR.enabled = false;
    }

    public void ChainGraphicReforme()
    {
        lineR.enabled = true;
    }

    public void SetGraphicValue()
    {
        float value;
        Material mat = lineR.material;
        value = maxLenghtChain - dstToTarget;
        float totValue = value / maxLenghtChain;
        mat.SetFloat("Vector1_57A4081A", Mathf.Clamp(totValue, 0, 1));
    }
}
