using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SkeletonWarriorGroundState : EnemyState
{
    public Enemy_SkeletonWarrior enemy;

    public Enemy_SkeletonWarriorGroundState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animatorBool, Enemy_SkeletonWarrior enemy) : base(_enemyBase, _stateMachine, _animatorBool)
    {
        this.enemy = enemy;
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

        if (enemy.IsPlayerInSightRange())
            stateMachine.ChangeState(enemy.chaseState);

        if (triggerCalled)
            stateMachine.ChangeState(enemy.idleState);
    }
}
