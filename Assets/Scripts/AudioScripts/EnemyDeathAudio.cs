using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathAudio : MonoBehaviour
{
    ChainController chainCtrl;
    PlayerLifeController playerCtrl;
    LevelManager levelMgr;
    AudioSource source;
    public AudioClip enemy, FemaleDmg, Horn;

    [Header("Settings")]
    [Range(0,1)]
    public float volume;
    private void Start()
    {
        chainCtrl = FindObjectOfType<ChainController>();
        playerCtrl = FindObjectOfType<PlayerLifeController>();
        levelMgr = FindObjectOfType<LevelManager>();
        source = GetComponent<AudioSource>();

        chainCtrl.AudioCall(() => 
        {
            source.PlayOneShot(enemy, volume);
        });

        playerCtrl.DamageTakenCall(() => 
        {
            source.PlayOneShot(FemaleDmg, volume);
        
        });

        levelMgr.StartWaveCall(() => 
        {
            source.PlayOneShot(Horn, 0.2f);
        
        });
    }
}
