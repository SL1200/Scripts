using UnityEngine.UI;
using UnityEngine;

public class LivesUpdater : MonoBehaviour {

	void Update ()
    {
        GetComponent<Text>().text = "" + GameSettings.instance.GetLives();
	}
}
