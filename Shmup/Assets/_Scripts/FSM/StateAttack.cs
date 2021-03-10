using UnityEngine;
public class StateAttack : State
{
    SteerableBehaviour steerable;
    IShooter shooter;
    GameManager gm;
    
    public override void Awake()
    {
        base.Awake();

        Transition ToPatrol = new Transition();
        ToPatrol.condition = new ConditionDistGT(transform,
            GameObject.FindWithTag("Player").transform,
            15.0f);
        ToPatrol.target = GetComponent<StatePatrol>();
        // Adicionamos a transição em nossa lista de transições
        transitions.Add(ToPatrol);

        steerable = GetComponent<SteerableBehaviour>();
        shooter = steerable as IShooter;
        if (shooter == null)
        {
            throw new MissingComponentException("This GameObject doesn't implement IShooter");
        }

        gm = GameManager.GetInstance(); 
    }

    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;
    public override void Update()
    {

        //TODO: Movimentação quando atacando

        if (Time.time - _lastShootTimestamp < shootDelay) return;
        _lastShootTimestamp = Time.time;
        if (gm.gameState != GameManager.GameState.GAME) return;
        shooter.Shoot();
    }
}