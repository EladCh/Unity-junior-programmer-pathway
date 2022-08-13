using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public Material material;
    private Color[] colors = { Color.blue, Color.red, Color.green, Color.black };
    private float[] scales = { 1.0f, 2.0f, 3.0f};
    private float prevColorUpdateTime;
    private float colorChangeRateSec = 1.5f;
    private float scaleChangeRateSec = 100.0f;
    private int bounceDirection = 1;
    private float yPos;
    private float xPos;
    private float zPos;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.localScale = Vector3.one * 1.3f;
        
        material = Renderer.material;
     
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
        prevColorUpdateTime  = scaleChangeRateSec = Time.time;
    }
    
    void Update()
    {
        // bounce the cube
        yPos = transform.position.y + (Random.Range(-5.0f, 7.0f) * bounceDirection * Time.deltaTime);
        xPos = transform.position.x + (Random.Range(-10.0f, 10.0f) * bounceDirection * Time.deltaTime);
        zPos = transform.position.z * 2 * bounceDirection * Time.deltaTime;
        transform.position = new Vector3(xPos, yPos, transform.position.z);
        // change rotation
        transform.Rotate(10.0f * Time.deltaTime, bounceDirection * 2.0f, bounceDirection * 1.0f);
        // change colors every colorChangeRateSec
        if (Time.time - prevColorUpdateTime > colorChangeRateSec)
        {
            int colorIdx = Random.Range(0, colors.Length);
            material.color = colors[colorIdx];
            prevColorUpdateTime = Time.time;
            // change scale
            int randomScaleIdx = Random.Range(0, scales.Length);
            transform.localScale = Vector3.one * scales[randomScaleIdx];
            // change direction
            bounceDirection *= -1;
        }
    }
}
