using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public Transform startingPoint;
    public float lerpSpeed;
    public float scoreIncrement = 5;
    public float score;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0.0f;

        playerControllerScript.gameOver = true;
        StartCoroutine(PlayIntro());
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

    IEnumerator PlayIntro()
    {
        // calculate starting and ending positions
        Vector3 startPos = playerControllerScript.transform.position;
        Vector3 endPos = startingPoint.transform.position;
        // calculate the distance between start and end positions
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;

        float distanceCovered;
        float fractionOfJourney;

        // reduce speed for the intro walk
        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);

        // iterate as long as the player haven't reach to endPos
        do
        {
            // calculate the distance covered and the fraction that passed from the road
            // in order to interpulate the player's current position 
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            // apply interpulated value to player's position
            playerControllerScript.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            yield return null;

        }
        while (fractionOfJourney < 1);
        
        // restore the animation speed to the original default
        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier", 1.0f);
        // update game state
        playerControllerScript.gameOver = false;
    }
}
