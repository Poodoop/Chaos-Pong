using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class AIControlAgent : Agent
{   
    [SerializeField] private Transform ball;
    [SerializeField] private Transform enemy;

    public float speed;
    private float previousDistanceToBall;

    public override void Initialize()
    {
        previousDistanceToBall = Vector2.Distance(transform.position, ball.position);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        if (transform != null)
        {   
        sensor.AddObservation(ball.position);
        sensor.AddObservation(transform.position);
        sensor.AddObservation(enemy.position);
        }
    }

    public override void OnActionReceived(ActionBuffers action)
    {
            float moveX = action.ContinuousActions[0];
            float moveY = action.ContinuousActions[1];

            transform.position += new Vector3(moveX, moveY, 0) * Time.deltaTime * speed;
    }

    private void FixedUpdate()
    {
        //Ball Distance
        float distanceToBall = Vector2.Distance(transform.position, ball.position);
        if (distanceToBall > previousDistanceToBall)
        {
            AddReward(-1f);
        }
        else
        {
            AddReward(0.1f);
        }
        previousDistanceToBall = distanceToBall;
    }   
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[1] = Input.GetAxisRaw("Vertical");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Ball Hitting
        if (other.gameObject != null && other.gameObject.name == "Ball")
        {
            AddReward(1f);
        }
    }
}