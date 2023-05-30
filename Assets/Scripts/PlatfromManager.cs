using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatfromManager : MonoBehaviour
{
    //[SerializeField] int indexCard;
    //[SerializeField] NumberManger manger;

    TextMeshPro text;
    private int a, b;
    private char symbol;

    void Awake()
    {
        text = transform.GetChild(4).GetComponent<TextMeshPro>();
    }

    public void SetNumbers(int a, char symbol, int b)
    {
        this.a = a;
        this.b = b;
        this.symbol = symbol;
        text.text = a + " " + symbol + " " + b;
    }

}
