using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacteriaGeneration : MonoBehaviour
{
    public GameObject purple;
    public GameObject yellow;
    public GameObject red;
    public GameObject player;
    private System.DateTime time;
    public int timediff;
    private System.Random rnd;
    public SceneLoader sl;
    private void Start()
    {
        time = System.DateTime.Now;
        rnd = new System.Random();
        player = GameObject.FindGameObjectWithTag("Player");
        sl = GetComponent<SceneLoader>();
    }
    void Update()
    {
        
        if (gameObject.IsDestroyed()) SceneManager.LoadScene("End");;
        System.DateTime currentTime = System.DateTime.Now;
        TimeSpan ts = currentTime - time;
        if (Convert.ToInt32(ts.TotalMilliseconds) > timediff)
        {
            float x = -100f + (float)rnd.NextDouble() * 200f;
            float y = -100f + (float)rnd.NextDouble() * 200f;
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


