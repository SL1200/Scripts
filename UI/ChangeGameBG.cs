using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameBG : MonoBehaviour {
    
    public static ChangeGameBG instance = null;

    public Sprite[] gameBackgrounds;

    private void Start()
    {
        SelectNewBG();
    }

    public void SelectNewBG()
    {
        // generate random number between 1 and 22 (total number of images)
        int randNum = Random.Range(1, 22);

        // gameBackgrounds is an array, an arrays index or position starts at 0
        // 22 images means the index goes from 0 - 21
        // we set a new int index to the value of the random number minus one
        int index = randNum - 1;

        // set new background
        GetComponent<SpriteRenderer>().sprite = gameBackgrounds[index];
    }

}
