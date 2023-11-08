using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public CircleCollider2D circleCollider;
    
    public AudioClip eatSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.localScale.x > collision.gameObject.transform.localScale.x)
        {
            float area = (collision.gameObject.transform.localScale.x / 2) * (collision.gameObject.transform.localScale.x / 2) * 3.14f;
            float x = (-2 * transform.localScale.x + Mathf.Sqrt(4 * Mathf.Pow(transform.localScale.x, 2f) + 4 * area / 3.14f)) / 2f;
            transform.localScale = new Vector3(transform.localScale.x + 2 * x, transform.localScale.y + 2 * x, 1);
            Destroy(collision.gameObject);
            
            audioSource.PlayOneShot(eatSound);
        } else
        {
            if (transform.localScale.x < collision.gameObject.transform.localScale.x)
            {
                float area = (transform.localScale.x / 2) * (transform.localScale.x / 2) * 3.14f;
                float x = (-2 * collision.gameObject.transform.localScale.x + Mathf.Sqrt(4 * Mathf.Pow(collision.gameObject.transform.localScale.x, 2f) + 4 * area / 3.14f)) / 2f;
                collision.gameObject.transform.localScale = new Vector3(collision.gameObject.transform.localScale.x + 2 * x, collision.gameObject.transform.localScale.y + 2 * x, 1);
                Destroy(gameObject);
            }
        }
    }
}
