using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class AlertManager : MonoBehaviour
{
    //TODO:
    // - Get Time event from Jeffs manager
    // - On event alert, trigger alert on screen
    public bool alertIsActive = false;
    public GameObject Alert_Symbol;
    public Text Alert_Text;
    TimeManager timeMan;
    int eventCount = 0;
    public int Alert_Time = 1;

    void Awake()
    {
    }

    // Use this for initialization
    void Start()
    {
        timeMan = FindObjectOfType<TimeManager>();
        timeMan.TimeIsUp += Trigger;
    }

    // Update is called once per frame
    void Update()
    {
        if(alertIsActive == false)
        {
            Alert_Symbol.SetActive(false);
            Alert_Text.enabled = false;
        }
        else
        {
            Alert_Symbol.SetActive(true);
            Alert_Text.enabled = true;
        }
    }

    private void Trigger(object sender, EventArgs e)
    {
        StartCoroutine(ResetTrue());
    }

    private IEnumerator ResetTrue()
    {
        alertIsActive = !alertIsActive;

        yield return new WaitForSeconds(Alert_Time);

        alertIsActive = !alertIsActive;
    }
}
