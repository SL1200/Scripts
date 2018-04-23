using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleLeftEnd : MonoBehaviour {

    public static PaddleLeftEnd instance = null;

    public Transform LeftToMiddlePoint;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void SetL2MP(Vector2 newPos)
    {
        Vector2 pos = newPos;
        this.transform.position = pos;
    }
}
