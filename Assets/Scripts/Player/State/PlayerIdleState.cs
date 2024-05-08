using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animatorBool) : base(_player, _stateMachine, _animatorBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.rb.velocity = Vector3.zero;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (_input != Vector3.zero)
            stateMachine.ChangeState(player.moveState);
    }
}
