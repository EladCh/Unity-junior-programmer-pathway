using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private float scoreIncrement = 5;
    public float score;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerControllerScript.gameOver)
        {
            score += playerControllerScript.isOnDash ? (2 * scoreIncrement) : scoreIncrement;
            Debug.Log("<color=green>Score: " + score + "</color>");
        }
    }
}
