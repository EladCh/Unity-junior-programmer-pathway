using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] Vector3 offset = new Vector3(0, 6, -10);

    // Update is called once per frame
    void LateUpdate()
    {
        // offset the camera behind the player by adding to the player's possition
        transform.position = player.transform.position + offset;
    }
}
