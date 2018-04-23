using UnityEngine;

public class PaddleMiddle : MonoBehaviour {

	public static PaddleMiddle instance = null;

    public Transform leftPoint;
    public Transform rightPoint;

    private float padWidth = 3f;

    private void Awake()
    {
        if(instance != null)
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
        SetPaddleWidth(padWidth);
    }

    private void Update()
    {
        Vector2 paddleLeftEnd = new Vector2(leftPoint.transform.position.x, leftPoint.transform.position.y);
        Vector2 paddleRightEnd = new Vector2(rightPoint.transform.position.x, rightPoint.transform.position.y);
        PaddleLeftEnd.instance.SetL2MP(paddleLeftEnd);
        PaddleRightEnd.instance.SetR2MP(paddleRightEnd);
    }

    public void SetPaddleWidth(float newPadWidth)
    {
        float padWidth = newPadWidth;
        transform.localScale = new Vector3(padWidth, 1f, 0f);
    }

    public void ResetPaddleWidth()
    {
        padWidth = 3f;
        transform.localScale = new Vector3(padWidth, 1f, 0f);
    }
}
