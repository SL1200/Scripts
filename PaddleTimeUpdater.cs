using UnityEngine.UI;
using UnityEngine;

public class PaddleTimeUpdater : MonoBehaviour {
    
	// Update is called once per frame
	void Update ()
    {
        //float time = BonusManager.instance.padSizeDuration;
        //int castTime = (int)time;
        GetComponent<Text>().text = ""; // + castTime
	}
}
