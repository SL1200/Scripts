using UnityEngine.UI;
using UnityEngine;

public class BombBallTimeUpdater : MonoBehaviour {

	// Update is called once per frame
	void Update ()
    {
        //float time = BonusManager.instance.GetBombBallDuration();
        //int castTime = (int)time;
        //GetComponent<Text>().text = "" + castTime;

        // does the pre-cast value actually needs to be a float / will it be displayed as such? if not change bonus durations to use an integer
        GetComponent<Text>().text = "" + (int)BonusManager.instance.GetBombBallDuration();
    }
}
