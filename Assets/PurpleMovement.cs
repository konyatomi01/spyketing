using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleMovement : MonoBehaviour
{
    public GameObject green;
    public float speed;
    
    public AudioClip eatSound;
    private AudioSource audioSource;

    public float proximityThreshold = 3.5f;

    Animator animator;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        CheckAngry();
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
            
            audioSource.PlayOneShot(eatSound);
        }
    }

    public void CheckAngry()
    {


        var p2 = GameObject.Find("player_4");
        var p3 = GameObject.Find("player_3");
        var p4 = GameObject.Find("player_7");

        animator.SetBool("isAngry", false);



        if ((IsTooClose(p4) && IsSmaller(p4)) ||
             (IsTooClose(p3) && IsSmaller(p3)) ||
             (IsTooClose(p4) && IsSmaller(p4)))
        {
            animator.SetBool("isAngry", true);
        }
    }



    bool IsSmaller(GameObject otherPlayer)
    {
        if (otherPlayer.transform.localScale.x < transform.localScale.x)
        {
            return true;
        }

        return false;
    }


    bool IsTooClose(GameObject otherPlayer)
    {
        if (otherPlayer != null)
        {
            float distance = Vector2.Distance(transform.position, otherPlayer.transform.position);
            return distance < proximityThreshold;
        }

        return false;
    }
}
