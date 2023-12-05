using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaGeneration : MonoBehaviour
{
    public GameObject purple;
    public GameObject yellow;
    public GameObject red;
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
            int z = rnd.Next();
            GameObject obj = purple;
            if (z % 3 == 0)
            {
                obj = purple;
            }
            if (z % 3 == 1)
            {
                obj = yellow;
            }
            if (z % 3 == 2)
            {
                obj = red;
            }
            Instantiate(obj, new Vector3(x, y, 1f), new Quaternion(0f, 0f, 0f, 0f));
            time = currentTime;
        }
    }
}
