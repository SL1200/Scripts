using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance = null;

    private string currentScene;
    private string nextScene;
    private int level = 1;
    private int stage = 1;

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

    private void Update()
    {
        if(GetScene() == "Start")
        {
            Paddle.instance.SetAutoPlay();
        }
    }

    public void LoadLevel(string name)
    {
        Block.breakableCount = 0;
        SceneManager.LoadScene(name);
    }

    void LoadNextLevel()
    {
        SetStage();
        nextScene = "Level" + level + "-" + stage;
        Block.breakableCount = 0;
        LoadLevel(nextScene);
    }

    private void SetStage()
    {
        if(stage == 5)
        {
            stage = 1;
            level++;
        }
        else
        {
            stage++;
        }
    }

    public void ResetLevel()
    {
        level = 1;
        stage = 1;
    }

    public string GetScene()
    {
        currentScene = SceneManager.GetActiveScene().name;
        return currentScene;
    }

    public void SetLost()
    {
        GameSettings.instance.SetLost();
    }

    public void TriggerReset()
    {
        ScoreManager.instance.ResetScoreAndLives();
    }

    //  todo : move to GameManager
    public void AllBlocksDestroyed()
    {
        if (Block.breakableCount <= 0)
            LoadNextLevel();
    }

    public void QuitRequest()
    {
        Application.Quit();
    }
}
