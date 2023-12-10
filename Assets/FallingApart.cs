using System;
using UnityEngine;

public class FallingApart : MonoBehaviour
{
    public GameObject prefab;
    private GameObject go;
    public GameObject collection;
    private bool isSplit = false;
    
    public AudioClip splitSound;
    private AudioSource audioSource;
    
    public float splitSpeed = 1f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(splitSound);
            if(!isSplit) SplitCell();
            else CombineCell();
        }
    }

    void SplitCell()
    {
        isSplit = true;
        go = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, 1f), Quaternion.identity);
        
        transform.localScale /= 2;
        go.transform.localScale = transform.localScale;
        go.transform.parent = collection.transform;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;
        go.transform.position = transform.position + moveDirection * 2.5f * transform.localScale.x;

        

    }

    void CombineCell()
    {
        isSplit = false;
        transform.localScale = transform.localScale + go.transform.localScale;
        Destroy(go);
    }
}