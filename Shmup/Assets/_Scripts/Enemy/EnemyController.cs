using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{

    GameManager gm;
    public HealthBar healthBar;
    public float lifes = 5f;
    private float maxLifes = 5f;
    private void Start()
    {
        gm = GameManager.GetInstance();
        healthBar.SetSize(lifes / maxLifes);
        healthBar.SetColor(Color.red);
    }

    public GameObject shot;
    public void Shoot()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
        Instantiate(shot, transform.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        lifes--;
        gm.score += 2;
        healthBar.SetSize(lifes / maxLifes);
        if (lifes <= 0) Die();
    }

    public AudioClip deathSFX;
    public void Die()
    {
        gm.score += 100;
        AudioManager.PlaySFX(deathSFX);
        Destroy(gameObject);
    }

    float angle = 0;

    private void FixedUpdate()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
        angle += 0.1f;
        Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);

        Thrust(x, y);

        if (transform.position.x < (GameObject.FindWithTag("Player").transform.position.x - 20))
        {
            Destroy(gameObject);
        }
    }
}
