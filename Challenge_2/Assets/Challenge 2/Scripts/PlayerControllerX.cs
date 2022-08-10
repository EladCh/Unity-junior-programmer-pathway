using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float lastActivationTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // set random inhibition time
            float inhibitionTime = Random.Range(0.2f, 1.0f);
            // instantiate only if the delta time from last inhibition
            // is greater than the inhibitionTime
            if (Time.time - lastActivationTime > inhibitionTime)
            {
                Instantiate(dogPrefab, transform.position, transform.rotation);
                // update the lastActivationTime
                lastActivationTime = Time.time;
            }
        }
    }
}
