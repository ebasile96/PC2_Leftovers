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
    }

    private void SetLineRender()
    {
        dirToTarget = (targetLine.position - transform.position).normalized;
        dstToTarget = Vector3.Distance(transform.position, targetLine.position);
        if (dstToTarget < maxLenghtChain && chainController.currentStressValue < 100)
        {
            lineR.enabled = true;
            lineR.SetPosition(0, transform.position);
            lineR.SetPosition(1, targetLine.position);
        }
        else
        {
            lineR.enabled = false;
        }
    }
}
