using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    private EnemyController enemy;
    private MeshRenderer mesh;
    private SphereCollider collider;
    public CapsuleCollider collidereEnemy;
    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponentInParent<EnemyController>();
        collidereEnemy = gameObject.GetComponentInParent<CapsuleCollider>();
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
            collidereEnemy.enabled = true;
            yield return new WaitForSeconds(enemy.Data.TimerBubble);
            isActive = false;
        }
        else if (isActive == false)
        {
            mesh.enabled = true;
            collider.enabled = true;
            collidereEnemy.enabled = false;
            yield return new WaitForSeconds(enemy.Data.TimerBubble);
            isActive = true;
        }
    }
}
