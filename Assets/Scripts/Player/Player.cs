using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    [Header("Move Info")]
    public float speed;
    public float jumpForce;

    [Header("Attack Info")]
    public float comboResetTime;

    #region State

    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerAttackState attackState { get; private set; }
    public PlayerDeathState deathState { get; private set; }
    public PlayerUsePotionState usePotionState { get; private set; }

    #endregion

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        attackState = new PlayerAttackState(this, stateMachine, "Attack");
        deathState = new PlayerDeathState(this, stateMachine, "Death");
        usePotionState = new PlayerUsePotionState(this, stateMachine, "UsePotion");
    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }

    public override void Death()
    {
        base.Death();
        stateMachine.ChangeState(deathState);
    }

    #region Trigger for Animation
    public void AnimationTrigger() => stateMachine.currentState.AnimationTriggerCalled();

    public void AttackTrigger()
    {
        Collider[] colliders = Physics.OverlapSphere(attackCheck.position, attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                hit.GetComponent<Enemy>().stats.TakeDamage(stats.damage);
            }
        }
    }

    public void DeathTrigger()
    {
        gameObject.SetActive(false);
    }
    #endregion

}
