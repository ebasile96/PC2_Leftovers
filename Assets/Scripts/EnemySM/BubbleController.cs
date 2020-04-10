﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    private EnemyController enemy;
    private MeshRenderer mesh;
    private SphereCollider collider;
    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponentInParent<EnemyController>();
        mesh = GetComponent<MeshRenderer>();
        collider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ActiveDisactiveBubble());
    }

    private IEnumerator ActiveDisactiveBubble()
    {
        if (isActive == true)
        {
            mesh.enabled = false;
            collider.enabled = false;
            yield return new WaitForSeconds(enemy.Data.TimerBubble);
            isActive = false;
        }
        else if (isActive == false)
        {
            mesh.enabled = true;
            collider.enabled = true;
            yield return new WaitForSeconds(enemy.Data.TimerBubble);
            isActive = true;
        }
    }
}
