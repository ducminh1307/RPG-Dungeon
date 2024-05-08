using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SkeletonWarriorDeathState : EnemyState
{
    private Enemy_SkeletonWarrior enemy;
    public Enemy_SkeletonWarriorDeathState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animatorBool, Enemy_SkeletonWarrior _enemy) : base(_enemyBase, _stateMachine, _animatorBool)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.agent.isStopped = true;
        enemy.rb.constraints = RigidbodyConstraints.FreezeAll;

        AudioSFXManager.instance.enemyDeathSound.Play();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
