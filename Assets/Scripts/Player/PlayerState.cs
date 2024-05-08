using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    protected Vector3 _input;

    private string animatorBool;

    protected float stateTimer;
    protected bool triggerCalled;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animatorBool)
    {
        player = _player;
        stateMachine = _stateMachine;
        animatorBool = _animatorBool;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animatorBool, true);

        triggerCalled = false;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;

        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //_input = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));
        player.anim.SetFloat("yVelocity", player.rb.velocity.y);
    }

    public virtual void Exit() 
    {
        player.anim.SetBool(animatorBool, false);
    }

    public virtual void AnimationTriggerCalled()
    {
        triggerCalled = true;
    }
}
