using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    static public EventController instance;

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    public event Action ElevetorUpEvent;

    public void ElevatorUp()
    {
        if(ElevetorUpEvent != null)
        {
            ElevetorUpEvent();
        }
    }

    public event Action ObsticalMoveEvent;

    public void ObsticalMove()
    {
        if(ObsticalMoveEvent != null)
        {
            ObsticalMoveEvent();
        }
    }

    public event Action PushCollectableItem;

    public void PushCollectable()
    {
        if(PushCollectableItem != null)
        {
            PushCollectableItem();
        }
    }

    public IEnumerator SyncTheTrail()
    {
        ElevatorUp();
        yield return new WaitForSecondsRealtime(2f);
        ObsticalMove();
        yield return new WaitForSecondsRealtime(2f);
    }
}