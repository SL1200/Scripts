using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBall : MonoBehaviour {

    public Paddle paddle;

    private static Rigidbody2D ballRB;
    private Vector2 startVelocity = new Vector2(2f, 5f);
    
    private float ballSpeedX;
    private float ballSpeedY;
    private float minBallSpeed = 4.0f;
    private float maxBallSpeed = 6.0f;

    public void RemoveBall()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        BallVelocityControl();  
    }

    void BallVelocityControl()
    {
        ballRB = GetComponent<Rigidbody2D>();
        ballSpeedX = ballRB.velocity.x;
        ballSpeedY = ballRB.velocity.y;
        Vector2 slowDown = new Vector2(maxBallSpeed, maxBallSpeed);
        Vector2 speedUp = new Vector2(minBallSpeed, minBallSpeed);
        if (ballSpeedX > maxBallSpeed || ballSpeedY > maxBallSpeed)
            ballRB.velocity = slowDown;
        if (ballSpeedX < minBallSpeed || ballSpeedY < minBallSpeed)
            ballRB.velocity = speedUp;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        /* 
            ballShift is used to prevent ball becoming stuck on a straight path,
            on each collision a new vector is used to give the ball a slight change in angle
            !!! can occasionally change direction of ball !!!
        */
        if (col.gameObject.tag == "LoseCollider")
        {
            RemoveBall();
        }
        else
        {
            Vector2 ballShift = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            GetComponent<Rigidbody2D>().velocity += ballShift;
        }
    }

    public void AutoPlay()
    {
        GetComponent<Rigidbody2D>().velocity = startVelocity;
    }
}
