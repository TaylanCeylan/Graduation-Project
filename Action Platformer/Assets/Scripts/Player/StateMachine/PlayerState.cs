using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;

    //It holds animation time.
    protected float startTime;

    //Animation reference
    private string animBoolName;

    //A constructor to create states for player.
    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        DoChecks();
        player.Animator.SetBool(animBoolName, true);
        startTime = Time.time;
    }

    public virtual void Exit()
    {
        player.Animator.SetBool(animBoolName, false);
    }

    //Do logical operations for player.
    public virtual void LogicUpdate()
    {

    }

    //Do physic operations such as rigidbody component.
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    //Do surrounding checks such as isGrounded etc.
    public virtual void DoChecks()
    {

    }
}
