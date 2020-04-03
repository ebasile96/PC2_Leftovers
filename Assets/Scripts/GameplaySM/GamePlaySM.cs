using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GamePlaySM : MonoBehaviour
{
    public Animator gp_anim;

    private void Awake()
    {
        gp_anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        
    }

    #region Events

    void HandleOnStartWave()
    {
        gp_anim.SetTrigger("GoToWave");
    }

    #endregion

    private void OnDisable()
    {
        
    }
}
