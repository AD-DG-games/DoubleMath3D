using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SetTextByCamera : MonoBehaviour
{
    [SerializeField] Color loseColor;
    [SerializeField] Color WinColor;
    // Start is called before the first frame update
    void Start()
    {
        Camera cam = GameObject.Find("Camera").GetComponent<Camera>();
        if (cam.backgroundColor == loseColor)
        {
            GameObject.Find("LoseSound").GetComponent<AudioSource>().Play();
            GetComponent<TextMeshProUGUI>().text = "You Lose";
        }
        else
        {
            GameObject.Find("WinSound").GetComponent<AudioSource>().Play();
            GetComponent<TextMeshProUGUI>().text = "You Win";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
