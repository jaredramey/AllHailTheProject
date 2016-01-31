using UnityEngine;
using System.Collections.Generic;
using System;


public class GraphManager : MonoBehaviour
{
    public int DataPointsCount = 100;
    public float minDataValue = 1;
    public float maxDataValue = 50;
    [Tooltip("Amount to shift the camera per each tick.")]
    public float shift;
    public GameObject linePrefab;

    Queue<float> dataList = new Queue<float>();
    TimeManager timeMan;
    Transform trans;
    GameObject line;
    LineRenderer lineRender;
    List<Vector3> positions = new List<Vector3>();

    void Awake()
    {
        trans = transform;

        CreateData();

        timeMan = FindObjectOfType<TimeManager>();
        timeMan.TimeIsUp += OnTimeUpEvent;
        line = Instantiate(linePrefab, Vector3.zero, Quaternion.identity) as GameObject;
        lineRender = line.GetComponent<LineRenderer>();
    }

    void CreateData()
    {
        for (int i = 0; i < DataPointsCount; i++)
        {
            dataList.Enqueue(UnityEngine.Random.Range(minDataValue, maxDataValue));
        }
    }


    private void OnTimeUpEvent(object sender, EventArgs e)
    {
        if (dataList.Count > 0)
        {
            Vector3 pos = trans.position;
            pos.y = dataList.Dequeue();
            positions.Add(pos);
            //set 
            lineRender.SetPositions(positions.ToArray());
            //move to the right
            trans.Translate(Vector3.right * shift);

        }


    }
}

