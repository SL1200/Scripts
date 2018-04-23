using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    public AudioClip loseMusic;
    public Ball ball;
    public ExtraBall extraBall;
    private int lives;

    void CheckLives()
    {
        lives = GameSettings.instance.GetLives();
        if(lives <= 0)
        {
            ball.RemoveBall();
            LevelManager.instance.LoadLevel("Lose");
            AudioManager.instance.SwapMusic(loseMusic);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            ball.ResetBall();
            GameSettings.instance.RemoveLife();
            CheckLives();
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "ExtraBall")
        {
            extraBall.RemoveBall();
        }
    }
}
