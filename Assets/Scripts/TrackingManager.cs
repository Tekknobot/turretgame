using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingManager : MonoBehaviour
{
    public Camera cam;
    bool bomberGone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Bomber") == null && bomberGone == false) {
            cam.GetComponent<TrackTargets>().targets.RemoveAt(1);
            bomberGone = true;
        }
    }
}
