using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotGeneration : MonoBehaviour
{
    public GameObject prefab;
    private System.DateTime time;
    public int timediff;
    private System.Random rnd;
    private void Start()
    {
        time = System.DateTime.Now;
        rnd = new System.Random();
    }
    void Update()
    {
        System.DateTime currentTime = System.DateTime.Now;
        TimeSpan ts = currentTime - time;
        if (Convert.ToInt32(ts.TotalMilliseconds) > timediff)
        {
            float x = -10f + (float)rnd.NextDouble() * 20f;
            float y = -10f + (float)rnd.NextDouble() * 20f;
            Instantiate(prefab, new Vector3(x, y, 1f), new Quaternion(0f, 0f, 0f, 0f));
            time = currentTime;
        }
    }
}
