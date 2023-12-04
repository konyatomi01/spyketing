using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class YellowMovement : MonoBehaviour
{
    public GameObject green;
    public float speed;
    
    public AudioClip eatSound;
    public AudioSource audioSource;

    
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        Vector3 vec = green.transform.position - transform.position;
        transform.position = transform.position + vec * speed * 0.001f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.localScale.x > collision.gameObject.transform.localScale.x)
        {
            float size = collision.gameObject.transform.localScale.x;
            Destroy(collision.gameObject);
            transform.localScale = new Vector3(transform.localScale.x + size, transform.localScale.y + size, 1);
            
            audioSource.PlayOneShot(eatSound);
        }
    }
}
