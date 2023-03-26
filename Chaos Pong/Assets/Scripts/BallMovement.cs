using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallMovement : MonoBehaviour
{
    public float speed; 
    public float extraSpeed;
    public float maxExtraSpeed;

    public bool playerStart = true;

    private int hitCounter = 0;

    private Rigidbody2D rb;

    void Start()
    {
        // Initial Velocity
        //GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Launch());
    }

    private void RestartBall()
    {
        rb.velocity = new Vector2(0,0);
        transform.position = new Vector2(0,0);
    }

    public IEnumerator Launch()
    {
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1);

        if(playerStart == true)
        {
            MoveBall(new Vector2(-1,0));
        }
        else
        {
            MoveBall(new Vector2(1,0));
        }
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;

        float ballSpeed = speed + hitCounter * extraSpeed;

        rb.velocity = direction * ballSpeed;
    }

    public void IncreaseHitCounter()
    {
        if(hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }
}