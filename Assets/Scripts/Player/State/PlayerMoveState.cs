using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    private Camera _camera;
    private Vector3 direction;
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animatorBool) : base(_player, _stateMachine, _animatorBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _camera = Camera.main;

        AudioSFXManager.instance.runSound.Play();
    }

    public override void Exit()
    {
        base.Exit();

        AudioSFXManager.instance.runSound.Stop();
    }

    public override void Update()
    {
        base.Update();

        Rotate();
        direction = (_camera.transform.forward * _input.z + _camera.transform.right * _input.x).normalized;
        direction.y = 0;

        player.rb.velocity = direction * player.speed;

        if (_input == Vector3.zero && player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
    }

    private void Rotate()
    {
        if (_input == Vector3.zero) return;

        Quaternion rotate = Quaternion.LookRotation(direction);
        player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, rotate, 360 * Time.deltaTime);
    }
}
