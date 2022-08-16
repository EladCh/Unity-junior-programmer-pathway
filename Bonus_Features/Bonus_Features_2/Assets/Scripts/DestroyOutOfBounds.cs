using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    private float sideBound = 30;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        else if (transform.position.x > sideBound)
        {
            // destroy farm animals that pass the right boundary
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        else if (transform.position.x < -sideBound)
        {
            // destroy farm animals that pass the right boundary
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
    }
}
