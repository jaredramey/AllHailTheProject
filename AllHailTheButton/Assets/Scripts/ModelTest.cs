

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ModelTest : MonoBehaviour
{
    // UI Elements to update
    private Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(RunModel());
    }

    IEnumerator RunModel()
    {
        const uint c_uNumIterations = 1000;
        DataModel.ITimeControlledObject model = new DataModel.Model();
        for (uint i = 0; i < c_uNumIterations; i++)
        {
            model.Trigger();
            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PushUpdate(List<float> team1, List<float> team2)
    {
        text.text = "";

        foreach (float f in team1)
        {
            text.text += f + " ";
        }
        foreach (float f in team2)
        {
            text.text += f + " ";
        }
    }
}
