using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0) {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        if (GetComponent<Target>().currentHealth <= 0) {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
