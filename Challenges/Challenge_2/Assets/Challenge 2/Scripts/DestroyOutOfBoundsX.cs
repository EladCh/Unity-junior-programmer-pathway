using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -25;
    private float bottomLimit = 0;

    // Update is called once per frame
    void Update()
    {
        // Destroy balls if y position less than left limit
        if (transform.position.y < bottomLimit)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        } 
        // Destroy dogs if x position is less than bottomLimit
        else if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }

    }
}
