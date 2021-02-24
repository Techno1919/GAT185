using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class StateAgent : Agent
{
    public StateMachine stateMachine { get; private set; }

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
    }

    void Update()
    {
        animator.SetFloat("Speed", movement.Velocity.magnitude);
        stateMachine.Execute();
    }
}
