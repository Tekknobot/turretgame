using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyDrop : MonoBehaviour
{
    public GameObject orb;
    public float repeatFire = 0.5f;

    // Start is called before the first frame update
    void OnEnable()
    {
        InvokeRepeating("StartSkyDrop", 0f, repeatFire);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartSkyDrop() {
        Instantiate(orb, transform.position, Quaternion.identity);
    }      
}
