using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour

{
    //private Rigidbody2D player;
    //public float speed;
    public GameObject obj; 

    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector2(obj.transform.position.x, obj.transform.position.y + 0.01f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            obj.transform.position = new Vector2(obj.transform.position.x, obj.transform.position.y - 0.01f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            obj.transform.position = new Vector2(obj.transform.position.x + 0.01f, obj.transform.position.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            obj.transform.position = new Vector2(obj.transform.position.x - 0.01f, obj.transform.position.y);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collision");
    }
}
