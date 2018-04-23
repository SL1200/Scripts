using UnityEngine;

public class Paddle : MonoBehaviour {
    // used on the Paddle prefab
    public static Paddle instance = null;

    public PaddleMiddle PM;
    public bool autoPlay = false;

    private float xScale;
    private float leftEnd = 0.32f;
    private float rightEnd = 0.32f;
    private float padWidth;
    private float buffLeft = 0.3f;
    private float buffRight = 0.3f;
    private Ball ball;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    private void Update()
    {
        xScale = PM.transform.localScale.x;
        padWidth = 0.08f * xScale;
        if(ball != null)
        {
            if(!autoPlay)
            {
                FollowMouse();
            }
            else
            {
                AutoPlay();
            }
        }
        else
        {
            Debug.Log("Ball not found!");
        }
    }

    void FollowMouse()
    {
        float boundryLeft = buffLeft + GetColliderCentre();
        float boundryRight = buffRight - GetColliderCentre();
        Vector2 paddlePos = new Vector2(0.7f, transform.position.y);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 7.2f;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, boundryLeft, boundryRight);
        transform.position = paddlePos;
        SetColliderWidth();
    }

    private void SetColliderWidth()
    {
        float newColliderWidth = leftEnd + rightEnd + padWidth;
        GetComponent<CapsuleCollider2D>().size = new Vector2(newColliderWidth, 0.41f);
    }

    private float GetColliderCentre()
    {
        float result = leftEnd + padWidth + rightEnd;
        return (result / 2);
    }

    public void SetAutoPlay()
    {
        if (!autoPlay)
            autoPlay = true;
        else
            autoPlay = false;
    }

    private void AutoPlay()
    {
        Vector2 paddlePos = new Vector2(0.7f, transform.position.y);
        Vector2 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 1.1f, 6.6f);
        transform.position = paddlePos;
    }
}
