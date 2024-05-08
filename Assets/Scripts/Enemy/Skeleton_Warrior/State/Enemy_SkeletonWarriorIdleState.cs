using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SkeletonWarriorIdleState : Enemy_SkeletonWarriorGroundState
{
    public Enemy_SkeletonWarriorIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animatorBool, Enemy_SkeletonWarrior enemy) : base(_enemyBase, _stateMachine, _animatorBool, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

        enemy.agent.isStopped = true;
        enemyBase.rb.velocity = Vector3.zero;
        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
        
        enemy.agent.isStopped = false;
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
        {
            enemy.RandomWalkPoint();
            stateMachine.ChangeState(enemy.moveState);

            if (enemy.IsPlayerInSightRange() && enemy.IsWallDetected())
                stateMachine.ChangeState(enemy.moveState);
        }

    }
}
