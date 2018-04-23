using UnityEngine;

public class WidthBonus : MonoBehaviour {

    private Vector2 startVelocity = new Vector2(0f, -3f);

    private void Start()
    {
        AutoPlay();
    }

    public void AutoPlay()
    {
        GetComponent<Rigidbody2D>().velocity = startVelocity;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Paddle")
        {
            float newWidth = RNG();
            PaddleMiddle.instance.SetPaddleWidth(newWidth);
            Destroy(gameObject);
        }
        else if(col.tag == "LoseCollider")
        {
            Destroy(gameObject);
        }
    }

    private float RNG()
    {
        int randomNumber = Random.Range(4, 10);
        float rng = (float)randomNumber;
        return rng;
    }

    
}
