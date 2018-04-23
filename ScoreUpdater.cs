using UnityEngine.UI;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour {

	// Update is called once per frame
    // script to be attatched to GameObject with textbox for score
	void Update ()
    {
        GetComponent<Text>().text = ""; //+ ScoreManager.instance.GetScore();
	}
}
