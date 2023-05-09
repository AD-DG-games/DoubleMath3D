using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreanManager : MonoBehaviour
{
    TextMeshPro time, number;
    // Start is called before the first frame update
    void Awake()
    {
        time = transform.GetChild(0).GetComponent<TextMeshPro>();
        number = transform.GetChild(1).GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool SetTime(int timeLeft)
    {
        time.text = "Time: " + timeLeft.ToString();
        return true;
    }
    public bool SetNumber(int num)
    {
        number.text = num.ToString();
        return true;
    }
}
