using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{

    Animator animator;
    private int lifes;
    private void Start()
    {
        animator = GetComponent<Animator>();
        lifes = 10;
    }

    public GameObject bullet;
    public Transform weapon01;
    private float shootDelay = 0.5f;
    private float _lattShootTimestamp = 0.0f;

    public AudioClip shootSFX;
    public void Shoot()
    {
        if (Time.time - _lattShootTimestamp < shootDelay) return;

        _lattShootTimestamp = Time.time;
        Instantiate(bullet, weapon01.transform.position, Quaternion.identity);
        AudioManager.PlaySFX(shootSFX);
    }

    public void TakeDamage()
    {
        lifes--;
        if (lifes <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);
        if (yInput != 0 || xInput != 0)
        {
            animator.SetFloat("Velocity", 1.0f);
        }
        else
        {
            animator.SetFloat("Velocity", 0.0f);
        }

        if (Input.GetAxisRaw("Fire1") != 0)
        {
            Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }
}
