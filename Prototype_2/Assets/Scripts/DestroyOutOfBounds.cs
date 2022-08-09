using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            // destroy pizzas that pass the top boundary
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            // if an animal passed the player - game ends
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
