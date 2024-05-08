using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animatorBool) : base(_player, _stateMachine, _animatorBool)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.rb.AddForce(new Vector3(_input.x, player.jumpForce, _input.z), ForceMode.Impulse);

        AudioSFXManager.instance.jumpSound.Play();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (player.rb.velocity.y < 0)
            stateMachine.ChangeState(player.airState);
    }
}
