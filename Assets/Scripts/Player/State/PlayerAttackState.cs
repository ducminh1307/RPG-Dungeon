using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    private int comboCounter;
    private float lastTimeAttacked;

    public PlayerAttackState(Player _player, PlayerStateMachine _stateMachine, string _animatorBool) : base(_player, _stateMachine, _animatorBool)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.rb.velocity = Vector3.zero;
        player.rb.constraints = RigidbodyConstraints.FreezeAll;
        

        if (comboCounter > 2 || Time.time > lastTimeAttacked + player.comboResetTime)
            comboCounter = 0;

        player.anim.SetInteger("AttackCounter", comboCounter);

        AudioSFXManager.instance.attackSound.Play();
    }

    public override void Exit()
    {
        base.Exit();
        player.rb.constraints = RigidbodyConstraints.FreezeRotation;

        comboCounter++;
        lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled)
            stateMachine.ChangeState(player.idleState);
    }
}
