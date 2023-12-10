using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class EnemyBacteriaAI : MonoBehaviour
{
    public float speed = 5f;
    public float detectionRadius = 10f;
    public string foodTag = "Food";
    public string bacteriaTag = "Bacteria";
    public string playerTag = "Player";
    
    public AudioClip eatSound;
    public AudioSource audioSource;

    private Transform target; 
    private Transform player; 
    
    Animator animator;
    public float proximityThreshold = 3.5f;
    
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        
        speed = 30f / (transform.localScale.x + 10f);
    }
    
    void Update()
    {
        speed = 30f / (transform.localScale.x + 10f);
        
        FindTarget(); 
        MoveToTarget(); 
        CheckAttack(); 
        CheckAngry();
    }
    
        void FindTarget()
    {
        GameObject[] foodItems = GameObject.FindGameObjectsWithTag(foodTag);
        GameObject[] enemyBacteria = GameObject.FindGameObjectsWithTag(bacteriaTag);
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        
        float minDistance = float.MaxValue;
        target = null;

        foreach (GameObject food in foodItems)
        {
            float distance = Vector3.Distance(transform.position, food.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                target = food.transform;
            }
        }

        foreach (GameObject enemy in enemyBacteria)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance && enemy.transform.localScale.x < transform.localScale.x)
            {
                minDistance = distance;
                target = enemy.transform;
            }
        }

        
        if (playerObject != null)
        {
            float playerDistance = Vector3.Distance(transform.position, playerObject.transform.position);
            if (playerDistance < minDistance && playerObject.transform.localScale.x < transform.localScale.x)
            {
                target = playerObject.transform;
            }
        }
    }

    void MoveToTarget()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    void CheckAttack()
    {
        if (target != null && target.CompareTag(bacteriaTag) && target.transform.localScale.x < transform.localScale.x)
        {
            
            Debug.Log("Attacking smaller bacteria!");
            Destroy(target.gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Rigidbody2D otherRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        
        if (otherRigidbody != null)
        {
            if (transform.localScale.x > otherRigidbody.transform.localScale.x)
            {
                Vector3 newScale = transform.localScale + 0.5f * otherRigidbody.transform.localScale;
                transform.localScale = newScale;

                audioSource.PlayOneShot(eatSound);
                
                Destroy(collision.gameObject);
            }
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
    
    public void CheckAngry()
    {
       

        var p2 = GameObject.Find("player_2");
        var p3 = GameObject.Find("player_3");
        var p4 = GameObject.Find("player_7");

        animator.SetBool("isAngry", false);



        if ((IsTooClose(p2) && IsSmaller(p2)) ||
            (IsTooClose(p3) && IsSmaller(p3)) ||
            (IsTooClose(p4) && IsSmaller(p4)))
        {
            animator.SetBool("isAngry", true);
        }
    }
    
}




