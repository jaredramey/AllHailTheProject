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

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(alertIsActive == false)
        {
            Alert_Symbol.GetComponent<MeshRenderer>().enabled = false;
            Alert_Text.text = "";
        }
        else
        {
            Alert_Symbol.GetComponent<MeshRenderer>().enabled = true;
            Alert_Text.text = "";
        }
    }

    void CheckTimeManager()
    {

    }
}
