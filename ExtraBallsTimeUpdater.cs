using UnityEngine.UI;
using UnityEngine;

public class ExtraBallsTimeUpdater : MonoBehaviour {

    private void Update()
    {
        //float time = BonusManager.instance.extraBallsDuration;
        //int castTime = (int)time;
        GetComponent<Text>().text = ""; // + castTime
    }

}
