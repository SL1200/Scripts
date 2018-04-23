using UnityEngine.UI;
using UnityEngine;

public class HighScoreUpdater : MonoBehaviour {

    private void Update()
    {
        GetComponent<Text>().text = "" + ScoreManager.instance.CheckHighScore();
    }
}
