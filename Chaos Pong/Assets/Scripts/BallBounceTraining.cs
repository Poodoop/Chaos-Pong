using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounceTraining : MonoBehaviour
{
    public BallMovement BallMovement;
    public ScoreManagerTraining scoreManagerTraining;

    private void Bounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;
        if(collision.gameObject.name == "Player")
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }

        float positionY = (ballPosition.y - racketPosition.y) / racketHeight;

        BallMovement.IncreaseHitCounter();
        BallMovement.MoveBall(new Vector2(positionX, positionY));
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.name == "Player" || collision.gameObject.name == "PlayerAI")
        {
            Bounce(collision);
        }
        else if(collision.gameObject.name == "Right Border")
        {
            scoreManagerTraining.PlayerGoal();
            BallMovement.playerStart = false;
            StartCoroutine(BallMovement.Launch());
        }
        else if(collision.gameObject.name == "Left Border")
        {
            scoreManagerTraining.PlayerAIGoal();
            BallMovement.playerStart = true;
            StartCoroutine(BallMovement.Launch());
        }
    }
}
