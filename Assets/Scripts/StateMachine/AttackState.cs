using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public float attackTimeMin = 0.5f;
    public float attackTimeMax = 2.0f;
    public float meleeDistance = 1.0f;

    float timer;
    float attackTimer;
    Vector3 lastTargetPosition;

    public override void Enter(Agent owner)
    {
        Debug.Log(GetType().Name + " Enter");
        attackTimer = Random.Range(attackTimeMin, attackTimeMax);
    }

    public override void Execute(Agent owner)
    {
        GameObject[] gameObjects = owner.perception.GetGameObjects();
        GameObject player = Perception.GetGameObjectFromTag(gameObjects, "Player");
        //player seen
        if (player != null)
        {
            lastTargetPosition = player.transform.position;
            timer = 1;

            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                float distance = Vector3.Distance(owner.transform.position, player.transform.position);
                if(distance < meleeDistance)
                {
                    ((StateAgent)owner).stateMachine.SetState("AttackMeleeState");
                }
                else
                {
                    ((StateAgent)owner).stateMachine.SetState("IdleState");
                }
            }
        }

        owner.movement.MoveTowards(lastTargetPosition);
    }

    public override void Exit(Agent owner)
    {
        Debug.Log(GetType().Name + " Exit");
    }
}
