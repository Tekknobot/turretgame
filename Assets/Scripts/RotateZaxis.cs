using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateZaxis : MonoBehaviour
{
    public float speed = 270f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.forward, Time.deltaTime * speed);
    }
}
