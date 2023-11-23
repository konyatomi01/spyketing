using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePlayerOnMouseDown : MonoBehaviour
{
    public GameObject obj;
    public double velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        Debug.Log("mouse down");
        //obj.transform.position = new Vector2(obj.transform.position.x - 1.0f, obj.transform.position.y);
        //obj.transform.position = Input.mousePosition;
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f; // zero z
        obj.transform.position = mouseWorldPos;
    }
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collision");
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("col");
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("col");
    }
    void OnCollisionStay2D(Collision2D col)
    {
        Debug.Log("hello");
    }
}
