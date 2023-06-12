using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScreen : MonoBehaviour
{
    public float end = -2;
    public float speed = -1.5f;
    private bool isInPlace = false;

    // Update is called once per frame
    void Update()
    {
        isInPlace = Mathf.Abs(transform.position.y - end) <= 1;
        if (!isInPlace) 
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
}
