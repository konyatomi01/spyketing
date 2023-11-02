using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMovement : MonoBehaviour
{
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
