using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerRotation : MonoBehaviour
{
    private int speed = 500;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // spin the propeller around itself
        transform.Rotate (Vector3.forward, Time.deltaTime * speed, Space.Self);
    }
}
