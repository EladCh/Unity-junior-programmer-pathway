using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;
    
    private List<string> TextToDisplay;
    
    private float RotatingSpeed;
    private float TimeToNextText;
    [SerializeField] private Vector3 centerOfMass;

    private int CurrentText;
    
    // Start is called before the first frame update
    void Start()
    {
        TimeToNextText = 0.0f;
        CurrentText = 0;
        
        RotatingSpeed = 0.5f;

        TextToDisplay = new List<string>
        {
            "Congratulation",
            "All Errors Fixed"
        };

        Text.text = TextToDisplay[0];

        SparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Text.gameObject.transform.RotateAround(centerOfMass, Vector3.up, RotatingSpeed);

        TimeToNextText += Time.deltaTime;

        if (TimeToNextText > 1.5f)
        {
            TimeToNextText = 0.0f;
            
            CurrentText++;
            if (CurrentText >= TextToDisplay.Count)
            {
                CurrentText = 0;
            }

            Text.text = TextToDisplay[CurrentText];
        }
    }
}