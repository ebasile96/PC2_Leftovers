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
}
