using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierAnimationManager : MonoBehaviour {


    public Animator Barrier;

    private bool barrierActive = false;

    private void Awake()
    {
        Barrier.speed = 0;
    }

    public bool isBarrierActive()
    {
        if (barrierActive)
            return true;
        else
            return false;
    }

    public void SetBarrierState(bool state)
    {
        barrierActive = state;
    }

    public void StopBarrier()
    {
        barrierActive = false;
        Barrier.speed = 0;
    }

    public void StartBarrier()
    {
        Barrier.speed = 1;
    }
}
