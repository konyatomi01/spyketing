using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CollectionMovement : MonoBehaviour
{
    public float speed;
    private float size;
    
    
    private bool isSplit = false;
    public GameObject prefab;
    private GameObject go;
    
    public AudioClip splitSound;
    private AudioSource audioSource;
    
    
    public CinemachineVirtualCamera camera;
    public TextMeshProUGUI score;

    private void Start()
    {
        size = childrenSize();
        camera.m_Lens.OrthographicSize = size + 5 * Mathf.Log(size + 1, 2f);
        score.text = (Math.Round((decimal)size, 2) * 10).ToString();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        size = childrenSize();
        camera.m_Lens.OrthographicSize = size + 5 * Mathf.Log(size + 1, 2f);
        camera.Follow = getBiggest().transform;
        
        if (transform.childCount==1) isSplit = false;
        else isSplit = true;
        
        speed = 40f / (transform.GetChild(0).gameObject.transform.localScale.x + 10f);
        score.text = (Math.Round((decimal)size, 2) * 10).ToString();
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        
        movement.Normalize();
        
        transform.Translate(movement * speed * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(splitSound);
            if(!isSplit) SplitCell();
            else CombineCell();
        }
    }

    private float childrenSize()
    {
        float sum = 0;
        foreach (Transform child in transform)
        {
            sum += child.localScale.x;
        }

        return sum;
    }

    private GameObject getBiggest()
    {
        GameObject gameObject = transform.GetChild(0).gameObject;
        foreach (Transform child in transform)
        {
            if (child.localScale.x > gameObject.transform.localScale.x) return child.gameObject;
        }

        return gameObject;

    }
    
    void SplitCell()
    {
        
        go = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, 1f), Quaternion.identity);
        
        transform.GetChild(0).transform.localScale /= 2;
        go.transform.localScale = transform.localScale;
        go.transform.parent = transform;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;
        go.transform.position = transform.position + moveDirection * 2.5f * transform.GetChild(0).transform.localScale.x;

        

    }

    void CombineCell()
    {
        transform.GetChild(0).transform.localScale = transform.GetChild(0).transform.localScale
                                                     + transform.GetChild(1).transform.localScale;
        Destroy(transform.GetChild(1));
    }
}
