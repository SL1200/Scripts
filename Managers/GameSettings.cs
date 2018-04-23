using UnityEngine;

public class GameSettings : MonoBehaviour {

    public static GameSettings instance = null;

    
    private string currentScene;
    private string gameType;
    private int lives = 3;
    private bool lost;
    private bool easy = true;
    private bool normal = false;
    private bool hard = false;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            lost = false;
            instance = this;
            DontDestroyOnLoad(this);
        }

    }

    void Start ()
    {
        SetBlockScore();
    }

    public string GetGameType()
    {
        return gameType;
    }

    public void SetGameTypeNormal()
    {
        gameType = "normal";
        Debug.Log("Gametype changed to Normal");
    }

    public void SetGameTypeRush()
    {
        gameType = "rush";
        Debug.Log("Gametype changed to Rush");
    }

    // Set score for each block via the ScoreManager depending on game difficulty
    public void SetBlockScore()
    {
        if(hard == true){
            ScoreManager.instance.SetBaseBlockScore(30);
        } else if (normal == true){
            ScoreManager.instance.SetBaseBlockScore(20);
        } else if(easy == true){
            ScoreManager.instance.SetBaseBlockScore(10);
        } else {
            Debug.Log("Failed to get difficulty");
            SetEasy();
            ScoreManager.instance.SetBaseBlockScore(10);
        }
    }

    // to be accessed from game options menu
    public void SetEasy()
    {
        easy = true; normal = false; hard = false;
    }

    public void SetNormal()
    {
        easy = false; normal = true; hard = false;
    }

    public void SetHard()
    {
        easy = false; normal = false; hard = true;
    }

    public void SetLost()
    {
        lost = true;
    }

    public void AddLives(int total)
    {
        lives = lives + total;
    }

    public void RemoveLife()
    {
        lives = lives - 1;
    }

    public int GetLives()
    {
        return lives;
    }

    public void ResetLives()
    {
        lives = 3;
    }


}
