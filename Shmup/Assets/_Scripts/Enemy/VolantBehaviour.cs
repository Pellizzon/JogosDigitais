using UnityEngine;
public class VolantBehaviour : SteerableBehaviour, IDamageable
{
    GameManager gm;
    public HealthBar healthBar;
    public float lifes = 2f;
    private float maxLifes = 2f;
    private void Start()
    {
        gm = GameManager.GetInstance();
        healthBar.SetSize(lifes / maxLifes);
        healthBar.SetColor(Color.cyan);
    }
    public void TakeDamage()
    {
        lifes--;
        healthBar.SetSize(lifes / maxLifes);
        if (lifes <= 0) Die();
    }

    public AudioClip deathSFX;
    public void Die()
    {
        gm.score += 20;
        AudioManager.PlaySFX(deathSFX);
        Destroy(gameObject);
    }
}
