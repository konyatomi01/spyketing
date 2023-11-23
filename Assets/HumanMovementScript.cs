using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class HumanMovementScript : MonoBehaviour
{
    public GameObject obj;
    private int direction;
    private System.Random rnd;
    private System.DateTime time;
    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
        rnd = new System.Random();
        time = System.DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        System.DateTime currentTime = System.DateTime.Now;
        //if (currentTime - time > )
        if (direction == 0)
        {
            obj.transform.position = new Vector2(obj.transform.position.x, obj.transform.position.y + 0.005f);
        }
        if (direction == 1)
        {
            obj.transform.position = new Vector2(obj.transform.position.x, obj.transform.position.y - 0.005f);
        }
        if (direction == 2)
        {
            obj.transform.position = new Vector2(obj.transform.position.x + 0.005f, obj.transform.position.y);
        }
        if (direction == 3)
        {
            obj.transform.position = new Vector2(obj.transform.position.x - 0.005f, obj.transform.position.y);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("bumm");
        int num = rnd.Next();
        while (num % 4 == direction)
        {
            num = rnd.Next();
        }
        if (num % 4 == 0)
        {
            direction = 0;
        }
        if (num % 4 == 1)
        {
            direction = 1;
        }
        if (num % 4 == 2)
        {
            direction = 2;
        }
        if (num % 4 == 3)
        {
            direction = 3;
        }
    }
    /*
    void OnCollisionStay2D(Collision2D col)
    {
        Debug.Log("hello");
        int num = rnd.Next();
        if (num % 4 == 0)
        {
            direction = 0;
        }
        if (num % 4 == 1)
        {
            direction = 1;
        }
        if (num % 4 == 2)
        {
            direction = 2;
        }
        if (num % 4 == 3)
        {
            direction = 3;
        }
    }
    */
}
