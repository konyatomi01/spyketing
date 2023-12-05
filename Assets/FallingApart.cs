using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingApart : MonoBehaviour
{
    public GameObject prefab;
    public GameObject collection;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            prefab.transform.localScale = new Vector3(transform.localScale.x / Mathf.Pow(2, 0.5f), transform.localScale.y / Mathf.Pow(2, 0.5f), transform.localScale.z);
            transform.localScale = new Vector3(transform.localScale.x / Mathf.Pow(2, 0.5f), transform.localScale.y / Mathf.Pow(2, 0.5f), transform.localScale.z);
            GameObject go = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, 1f), new Quaternion(0f, 0f, 0f, 0f));
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.D))
                {
                    go.transform.position = new Vector3(go.transform.position.x + 0.001f, go.transform.position.y, 1f);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    go.transform.position = new Vector3(go.transform.position.x - 0.001f, go.transform.position.y, 1f);
                }
                if (Input.GetKey(KeyCode.W))
                {
                    go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y + 0.001f, 1f);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y - 0.001f, 1f);
                }
            } else {
                go.transform.position = new Vector3(go.transform.position.x + 0.001f, go.transform.position.y, 1f);
            }
            go.transform.parent = collection.transform;
        }
    }
}
