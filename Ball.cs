using UnityEngine;

public class Ball : MonoBehaviour {

    public Paddle paddle;

    private static Rigidbody2D ballRB;
    private Vector2 startVelocity = new Vector2(2f, 5f);
    private Vector3 ballToPaddleVector;

    private bool hasStarted = false;
    private float ballSpeedX;
    private float ballSpeedY;
    private float minBallSpeed = 5.0f;
    private float maxBallSpeed = 6.0f;

    private void Start()
    {
        // sets ballToPaddleVector with offset
        ballToPaddleVector = transform.position - paddle.transform.position;
    }

    public void ResetBall()
    {
        hasStarted = false;
    }

    public void RemoveBall()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        
        if(!hasStarted)
        {   // if game has not started place ball at the paddle's position + the offset
            transform.position = paddle.transform.position + ballToPaddleVector;
            // if user clicks mouse button start ball moving
            if(Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                GetComponent<Rigidbody2D>().velocity = startVelocity;
            }
        }
        // if game already started, manage ball speed.
        else
        {
            BallVelocityControl();
        }
    }

    // checks velocity of ball and adjusts as needed
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
            ballShift is used to help prevent ball becoming stuck on a straight path,
            on each collision a new vector is used to give the ball a slight change in angle
            downside is ball can change direction if similar consecutive ranges are generated.
        */
        Vector2 ballShift = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
        GetComponent<Rigidbody2D>().velocity += ballShift;
    }

    public void AutoPlay()
    {
        GetComponent<Rigidbody2D>().velocity = startVelocity;
    }
}
