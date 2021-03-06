using UnityEngine;

public class VolantBehaviour : SteerableBehaviour, IDamageable

{
    public int lifes = 2;

    public void TakeDamage()
    {
        lifes--;
        if (lifes <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    // float angle = 0;
    // private void FixedUpdate()
    // {
    //     angle += 0.1f;
    //     if (angle > 2.0f * Mathf.PI) angle = 0.0f;
    //     Thrust(0, Mathf.Cos(angle));
    // }
}
