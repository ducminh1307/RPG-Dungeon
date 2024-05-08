using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SkeletonWarriorAttackState : EnemyState
{
    public Enemy_SkeletonWarrior enemy;
    public Enemy_SkeletonWarriorAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animatorBool, Enemy_SkeletonWarrior enemy) : base(_enemyBase, _stateMachine, _animatorBool)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.agent.isStopped = true;
        enemy.rb.velocity = Vector3.zero;
        enemy.rb.constraints = RigidbodyConstraints.FreezeAll;

        enemy.lastTimeAttacked = Time.time;
    }

    public override void Exit()
    {
        base.Exit();

        enemy.rb.constraints = RigidbodyConstraints.FreezeRotation;
        enemy.agent.isStopped = false;
    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled)
            stateMachine.ChangeState(enemy.idleState);
    }
}
