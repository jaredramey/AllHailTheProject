using UnityEngine;
using System.Collections.Generic;
using System;

public class TimeManager : MonoBehaviour
{
    //simuates the passing of a day in x amounts of seconds.
    public float timeToTrigger = 1;
    public event EventHandler TimeIsUp;

    private float timer = 0;
    

    void Update()
    {
        if(timer < timeToTrigger)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            OnTimeIsUp(EventArgs.Empty);
        }
    }

    protected virtual void OnTimeIsUp(EventArgs e)
    {
        EventHandler handler = TimeIsUp;
        if(handler != null)
        {
            handler(this, e);
        }
    }


}
