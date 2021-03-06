using UnityEngine;
public class StatePatrolForWaypoints : State
{
    // Transform[] waypoints;
    Rigidbody2D rb;

    public override void Awake()
    {
        base.Awake();
        // Configure a transição para outro estado aqui.
        rb = GetComponent<Rigidbody2D>();
    }

    // public void Start()
    // {
    //     waypoints[0].position = transform.position;
    //     waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
    // }

    public override void Update()
    {
        Vector3 playerPos = GameObject.FindWithTag("Player").transform.position;

        if (Vector3.Distance(transform.position, playerPos) > .1f)
        {
            Vector3 direction = playerPos - transform.position;
            direction.Normalize();
            rb.MovePosition(rb.position + new Vector2(direction.x, direction.y) * Time.fixedDeltaTime);
        }
        else
        {
            playerPos = GameObject.FindWithTag("Player").transform.position;
        }
    }

}
