using UnityEngine.UI;
using UnityEngine;

public class BarrierTimeUpdater : MonoBehaviour {

	// Update is called once per frame
	void Update ()
    {
        //float time = BonusManager.instance.barrierDuration;
        //int castTime = (int)time;
        GetComponent<Text>().text = ""; // + castTime
    }
}
