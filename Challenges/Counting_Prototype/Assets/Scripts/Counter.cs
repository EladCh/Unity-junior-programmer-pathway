using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    public string type;

    private int Count = 0;

    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Count ++;
        if(type == "Good")
        {
            SetText(Count);
        }
    }

    public void SetText(int count)
    {
        CounterText.text = type + " Count : " + count;
    }

    public int GetCount() { return Count; }
}
