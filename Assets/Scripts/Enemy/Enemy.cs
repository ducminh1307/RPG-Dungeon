using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    public NavMeshAgent agent { get; private set; }

    [Header("Check player info")]
    [SerializeField] private float playerInAttackRange = 1f;
    [SerializeField] private float playerInSightRange = 4f;
    [SerializeField] private LayerMask whatIsPlayer;

    [Header("Move Info")]
    public float idleTime;
    public float moveTime;
    public float walkPointRange;
    public Vector3 walkPoint { get; private set; }
    [SerializeField] private LayerMask whatIsWall;

    [Header("Attack Info")]
    public float attackCooldown;
    [HideInInspector] public float lastTimeAttacked;

    #region State

    public EnemyStateMachine stateMachine { get; private set; }

    #endregion

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new EnemyStateMachine();
    }

    protected override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
    }

    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();
    }

    public void RandomWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    }

    public override void Death()
    {
        base.Death();
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), playerInAttackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), playerInSightRange);
    }

    #region Collison

    public bool IsWallDetected() => Physics.CheckSphere(transform.position, 2f, whatIsWall);

    public bool IsPlayerInSightRange() => Physics.CheckSphere(transform.position, playerInSightRange, whatIsPlayer);
    public bool IsPlayerInAttackRange() => Physics.CheckSphere(transform.position, playerInAttackRange, whatIsPlayer);

    #endregion

    #region Trigger for Animation
    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    public void AttackTrigger()
    {
        Collider[] colliders = Physics.OverlapSphere(attackCheck.position, attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                hit.GetComponent<Player>().stats.TakeDamage(stats.damage);
            }
        }
    }
    public void DeathTrigger()
    {
        Destroy(gameObject);
    }
    #endregion

}
