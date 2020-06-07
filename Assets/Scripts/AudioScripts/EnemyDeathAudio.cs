using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathAudio : MonoBehaviour
{
    ChainController chainCtrl;
    PlayerLifeController playerCtrl;
    AudioSource source;
    public AudioClip enemy;
    public AudioClip FemaleDmg;

    [Header("Settings")]
    [Range(0,1)]
    public float volume;
    private void Start()
    {
        chainCtrl = FindObjectOfType<ChainController>();
        playerCtrl = FindObjectOfType<PlayerLifeController>();
        source = GetComponent<AudioSource>();
        chainCtrl.AudioCall(() => 
        {
            source.PlayOneShot(enemy, volume);
        });

        playerCtrl.DamageTakenCall(() => 
        {
            source.PlayOneShot(FemaleDmg, volume);
        
        });
    }
}
