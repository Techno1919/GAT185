using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentBehaviour : Behaviour
{
    public override Vector3 Execute()
    {
        Vector3 force = Vector3.zero;

        GameObject[] gameObjects = perception.GetGameObjects();
        if (gameObjects != null && gameObjects.Length > 0)
        {
            // ****
            Vector3 velocities = Vector3.zero;
            foreach (GameObject gameObject in gameObjects)
            {
                AutonomousAgent agent = gameObject.GetComponent<AutonomousAgent>();
                velocities = velocities + agent.Velocity;
            }

            Vector3 direction = (velocities / gameObjects.Length).normalized;//(< calculate the average velocity >).normalized;

            // ****

            Vector3 desired = direction * Agent.maxSpeed;
            force = Vector3.ClampMagnitude(desired - Agent.Velocity, Agent.maxForce);

            Debug.DrawRay(transform.position, desired, Color.red); // desired
            Debug.DrawRay(transform.position + Agent.Velocity, force, Color.green); // steering

        }

        return force;
    }
}
