using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SkeletonWarrior : Enemy
{

    #region State

    public Enemy_SkeletonWarriorIdleState idleState { get; private set; }
    public Enemy_SkeletonWarriorMoveState moveState { get; private set; }
    public Enemy_SkeletonWarriorChaseState chaseState { get; private set; }
    public Enemy_SkeletonWarriorAttackState attackState { get; private set; }
    public Enemy_SkeletonWarriorDeathState deathState { get; private set; }

    #endregion

    protected override void Awake()
    {
        base.Awake();

        idleState = new Enemy_SkeletonWarriorIdleState(this, stateMachine, "Idle", this);
        moveState = new Enemy_SkeletonWarriorMoveState(this, stateMachine, "Move", this);
        chaseState = new Enemy_SkeletonWarriorChaseState(this, stateMachine, "Chase", this);
        attackState = new Enemy_SkeletonWarriorAttackState(this, stateMachine, "Attack", this);
        deathState = new Enemy_SkeletonWarriorDeathState(this, stateMachine, "Death", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Death()
    {
        base.Death();
        stateMachine.ChangeState(deathState);
    }
}
