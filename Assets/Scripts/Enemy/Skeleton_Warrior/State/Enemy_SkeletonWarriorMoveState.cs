using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SkeletonWarriorMoveState : Enemy_SkeletonWarriorGroundState
{
    public Enemy_SkeletonWarriorMoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animatorBool, Enemy_SkeletonWarrior enemy) : base(_enemyBase, _stateMachine, _animatorBool, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

        enemy.agent.SetDestination(enemy.walkPoint);
        stateTimer = enemy.moveTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        Vector3 distanceToWalkPoint = enemy.transform.position - enemy.walkPoint;

        if (distanceToWalkPoint.magnitude < 1 || (enemy.IsWallDetected() && stateTimer < 0))
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
