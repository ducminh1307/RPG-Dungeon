using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUsePotionState : PlayerState
{
    public PlayerUsePotionState(Player _player, PlayerStateMachine _stateMachine, string _animatorBool) : base(_player, _stateMachine, _animatorBool)
    {
    }

    public override void Enter()
    {
        base.Enter();

        PotionManager.instance.UsePotion();
        player.stats.Health(PotionManager.instance.healthPower);

        AudioSFXManager.instance.usePotionSound.Play();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
