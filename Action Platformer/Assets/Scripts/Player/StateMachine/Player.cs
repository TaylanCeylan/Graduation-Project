using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Create a state machine object for a player.
    public PlayerStateMachine StateMachine { get; private set; }

    public IdleState IdleState { get; private set; }

    public RunState RunState { get; private set; }

    public Animator Animator { get; private set; }

    public InputHandler InputHandler { get; private set; }

    [SerializeField]
    private PlayerData _playerData;

    private readonly string IDLE_ANIM = "idle";
    private readonly string RUN_ANIM = "run";

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new IdleState(this, StateMachine, _playerData, IDLE_ANIM);
        RunState = new RunState(this, StateMachine, _playerData, RUN_ANIM);
    }

    private void Start()
    {
        Animator = GetComponent<Animator>();
        InputHandler = GetComponent<InputHandler>();

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
}
