using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera overheadCamera;

    private int cameraState = 0;

    // disable FPS camera and enable overhead camera.
    public void ShowOverheadView() {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
    }
    
    // enable FPS camera and disable overhead camera.
    public void ShowFirstPersonView() {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        ShowOverheadView();
    }

    // Update is called once per frame
    void Update()
    {
        // change views by pressing the left ctrl button
        if (Input.GetButtonDown("Fire1"))
        {
            if (cameraState == 0) {
                ShowOverheadView();
            }
            else {
                ShowFirstPersonView();
            }
            // change the camera state
            cameraState^=1;
        }
    }
}
