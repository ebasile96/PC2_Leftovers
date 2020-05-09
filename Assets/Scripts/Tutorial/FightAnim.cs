using SemihOrhan.WaveOne;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightAnim : MonoBehaviour
{
    public GameObject fence;
    public WaveManager waveMgr;

   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            waveMgr.StartAllConfigWaves();
        }
             
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.tag == "Pet")
        {
            if (fence.transform.position.y < 0)
            {
                fence.transform.position += new Vector3(0, 2, 0);
            }
        }
            
    }
}
