﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleRightEnd : MonoBehaviour {

    public static PaddleRightEnd instance = null;

    public Transform RightToMiddlePoint;

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

    public void SetR2MP(Vector2 newPos)
    {
        Vector2 pos = newPos;
        transform.position = pos;
    }
}
