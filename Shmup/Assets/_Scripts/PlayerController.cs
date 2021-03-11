using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{

    Animator animator;
    private float maxLifes;
    public HealthBar healthBar;
    GameManager gm;

    private Vector2 screenBounds;
    private float objHeight;
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;

        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();

        maxLifes = 10.0f;
        healthBar.SetSize(gm.lifes / maxLifes);
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
        gm.lifes--;
        healthBar.SetSize(gm.lifes / maxLifes);
        if (gm.lifes <= 0) Die();
    }

    public void Die()
    {
        if (gm.lifes <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
        gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);

        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, objHeight - screenBounds.y, screenBounds.y - objHeight);
        transform.position = pos;

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

        if (Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.PAUSE);
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
