using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShieldDamage : MonoBehaviour
{
    public  PlayerLifeController pHealth;
    public  VFXManager vfx;
    public  EnemyController enemy;

    // Start is called before the first frame update
    void Start()
    {
        vfx = FindObjectOfType<VFXManager>();
        pHealth = FindObjectOfType<PlayerLifeController>();
        enemy = gameObject.GetComponentInParent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private bool canTakeDamage = true;

    public void OnCollisionStay(Collision hit)
    {

        if (hit.gameObject.tag == "Player" && canTakeDamage == true)
        {
            pHealth.TakeDamage(enemy.Data.damageShield);
            Instantiate(vfx.vfxHitTest, hit.transform);
            //SoundManager.PlaySound(SoundManager.Sound.femaleTakeDamage);

            StartCoroutine(damageTimer());
        }
    }
    private IEnumerator damageTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(enemy.Data.rateoDamage);
        canTakeDamage = true;
    }
}
