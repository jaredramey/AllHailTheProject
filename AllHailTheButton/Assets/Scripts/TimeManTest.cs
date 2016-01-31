using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TimeManTest : MonoBehaviour
{
    Text text;
    TimeManager timeMan;
    int eventCount = 0;

    void Awake()
    {
        text = GetComponent<Text>();

    }

    void Start()
    {
        timeMan = FindObjectOfType<TimeManager>();
        timeMan.TimeIsUp += Trigger;
    }

    private void Trigger(object sender, EventArgs e)
    {
        text.text = "Trigger events received: " + ++eventCount;
    }
}
