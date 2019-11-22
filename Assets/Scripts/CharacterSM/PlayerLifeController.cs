using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeController : MonoBehaviour
{
    public float healthPlayer;
    public float damage;
    public Slider hpBarPlayer;
    public Transform positionPlayer;

    public void Start()
    {
        hpBarPlayer = FindObjectOfType<Slider>();
        positionPlayer = GetComponent<Transform>();
    }

    public void TakeDamage(float _damage)
    {
        healthPlayer -= _damage;
    }

    private void Update()
    {
        hpBarPlayer.value = healthPlayer;

        if (healthPlayer <= 0)
        {
            positionPlayer.position += new Vector3(0.0f, 0.8f, -20f);
            healthPlayer = 3;
        }
    }
}
