﻿using UnityEngine;

public class ShotBehaviour : SteerableBehaviour
{

    GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }
    private void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
        Thrust(1, 0);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return;

        IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if (!(damageable is null))
        {
            damageable.TakeDamage();
        }
        Destroy(gameObject);
    }
}