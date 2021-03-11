using System.Collections;
using UnityEngine;

// https://answers.unity.com/questions/399385/how-do-i-spawn-enemies-based-on-a-timer.html
// https://answers.unity.com/questions/772331/spawn-object-in-front-of-player-and-the-way-he-is.html
public class EnemyPool : MonoBehaviour
{
    public GameObject purpleEnemy;
    public GameObject asteroid;
    GameManager gm;
    private float Timer;

    void Start()
    {
        gm = GameManager.GetInstance();
        Timer = Time.time;
    }

    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        GameObject player = GameObject.FindWithTag("Player");

        Vector3 playerPos = player.transform.position;
        playerPos.y = Random.Range(-4.0f, 4.0f);
        Vector3 playerDirection = player.transform.right;
        Quaternion playerRotation = player.transform.rotation;

        float spawnDistance = 20;

        Vector3 spawnPos = playerPos + spawnDistance * playerDirection;
        if (Timer < Time.time)
        {
            if (Random.Range(0.0f, 1.0f) < 0.7f)
            {
                Instantiate(purpleEnemy, spawnPos, playerRotation);
                Timer = Time.time + 2;
            }
            else
            {
                Instantiate(asteroid, spawnPos, playerRotation);
                Timer = Time.time + 3;
            }
        }

    }
}
