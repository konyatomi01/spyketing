using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = transform.localScale * 1.2f;
    }

    public float scaleSpeed = 1.0f; // Adjust the speed of the scaling
    public float scaleFactor = 0.1f; // Adjust the amplitude of the sine wave

    void Update()
    {
        // Calculate the new scale using a sine function
        float newScale = Mathf.Sin(Time.time * scaleSpeed) * scaleFactor;

        // Apply the new scale to the object
        transform.localScale = new Vector3(1 + newScale, 1 + newScale, 1 + newScale);
    }
}
