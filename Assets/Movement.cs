using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public CircleCollider2D circleCollider;
    
    public AudioClip eatSound;
    private AudioSource audioSource;

    public CinemachineVirtualCamera camera;
    public int cameraDistance=40;

    public TextMeshProUGUI score;

    public settings Settings;

    public float proximityThreshold = 3.5f;

    Animator animator;
 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        Settings = GameObject.FindWithTag("settings").GetComponent<settings>();
        switch (Settings.difficulty)
        {
            case 1:
                transform.localScale = transform.localScale * 1;
                break;
            case 2:
                transform.localScale = transform.localScale * 0.7f;
                break;
            case 3:
                transform.localScale = transform.localScale * 0.5f;
                break;
        }
    }

    void Update()
    {
        CheckScared();
        //camera.m_Lens.OrthographicSize = 1/( 16/ (gameObject.transform.localScale.x * cameraDistance));
        camera.m_Lens.OrthographicSize = 2 * Mathf.Log(gameObject.transform.localScale.x + 2, 1.3f);

        score.text = (Math.Round((decimal)gameObject.transform.localScale.x, 2) * 10).ToString();

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

    public void CheckScared()
    {
        int x = 0;

        var p2 = GameObject.Find("player_2");
        var p3 = GameObject.Find("player_3");
        var p4 = GameObject.Find("player_4");

        animator.SetBool("isScared", false);

        if (IsBigger(p2) )
        {
            x++;
        }

        if (IsBigger(p3))
        {
            x++;
        }

        if (IsBigger(p4))
        {
            x++;
        }

        if (x > 1)
        {
            animator.SetBool("isScared", true);
        }



        if ( ( IsTooClose(p2) && IsBigger(p2) ) || 
             ( IsTooClose(p3) && IsBigger(p3) ) || 
             ( IsTooClose(p4) && IsBigger(p4) ) )
        {
            animator.SetBool("isScared", true);
        }
    }

    bool IsBigger(GameObject otherPlayer)
    {
        if (otherPlayer.transform.localScale.x > transform.localScale.x)
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
