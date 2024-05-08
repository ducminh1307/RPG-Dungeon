using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SkeletonWarriorChaseState : EnemyState
{
    public Enemy_SkeletonWarrior enemy;
    public Enemy_SkeletonWarriorChaseState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animatorBool, Enemy_SkeletonWarrior _enemy) : base(_enemyBase, _stateMachine, _animatorBool)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        enemy.agent.SetDestination(PlayerManager.instance.player.transform.position);

        if (!enemy.IsPlayerInSightRange())
            stateMachine.ChangeState(enemy.idleState);

        if (enemy.IsPlayerInAttackRange() && CanAttack())
            stateMachine.ChangeState(enemy.attackState);
    }

    private bool CanAttack()
    {
        if (Time.time > enemy.lastTimeAttacked + enemy.attackCooldown)
            return true;
        return false;
    }
}
