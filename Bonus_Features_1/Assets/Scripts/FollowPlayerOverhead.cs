using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerOverhead : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 3, -2);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // offset the camera behind the player by adding to the player's possition
        transform.position = player.transform.position + offset;
    }
}
