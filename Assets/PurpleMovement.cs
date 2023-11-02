using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleMovement : MonoBehaviour
{
    public GameObject green;
    public float speed;
    void Update()
    {
        if (green.transform.localScale.x < transform.localScale.x)
        {
            Vector3 vec = green.transform.position - transform.position;
            transform.position = transform.position + vec * speed * 0.001f;
        } else
        {
            if (green.transform.localScale.x > transform.localScale.x)
            {
                Vector3 vec = green.transform.position - transform.position;
                transform.position = transform.position - vec * speed * 0.001f;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.localScale.x > collision.gameObject.transform.localScale.x)
        {
            float size = collision.gameObject.transform.localScale.x;
            Destroy(collision.gameObject);
            transform.localScale = new Vector3(transform.localScale.x + size, transform.localScale.y + size, 1);
        }
    }
}
