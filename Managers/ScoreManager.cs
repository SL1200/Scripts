using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance = null;

    private int score = 0;
    private int highScore = 400; // use .txt file to save high-score
    private int baseBlockScore;
    private int blockScore;
    private int timesHit;

    void Awake()
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

    public void SetBaseBlockScore(int newBBS)
    {
        baseBlockScore = newBBS;
    }

    public int GetBaseBlockScore()
    {
        return baseBlockScore;
    }

    public void SetTimesHit(int newTimesHit)
    {
        timesHit = newTimesHit;
    }

    private void SetScore(int newScore)
    {
        score = score + newScore;
    }

    public int GetScore()
    {
        return score;
    }

    public int CheckHighScore()
    {
        return highScore;
    }

    public void UpdateHighScore()
    {
        if (score > highScore)
            highScore = score;
    }

    public void AddPointsToScore()
    {
        blockScore = baseBlockScore * timesHit;
        SetScore(blockScore);
    }

    public void ResetScoreAndLives()
    {
        //bool lost = GameSettings.instance.lost;
        int lives = GameSettings.instance.GetLives();
        string activeScene = LevelManager.instance.GetScene();
        if(activeScene == "Lose") // lost == true &&
        {
            if(score != 0 && lives <= 0)
            {
                score = 0;
                GameSettings.instance.ResetLives();
                
            }
        }
    }
}
