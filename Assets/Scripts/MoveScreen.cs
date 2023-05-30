using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScreen : MonoBehaviour
{
    public float end = -2;
    public float speed = -1.5f;

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.y - end) > 0.01) 
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
}
