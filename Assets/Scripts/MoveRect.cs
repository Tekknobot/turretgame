using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRect : MonoBehaviour
{
    //Declare RectTransform in script
    RectTransform target;
    //The new position of your target
    Vector3 newPos = new Vector3(0, 75.9f, 0);
    Vector3 oldPos = new Vector3(0, 106.3f, 0);
    //Reference value used for the Smoothdamp method
    private Vector3 buttonVelocity = Vector3.zero;
    //Smooth time
    public float smoothTime = 0.5f;

    public bool hasTargetMoved = false;
 
    void Start()
    {
        //Get the RectTransform component
        target = GetComponent<RectTransform>();
    }
    
    void Update()
    {
        //Update the localPosition towards the newPos
        if (hasTargetMoved == false) {
            target.localPosition = Vector3.SmoothDamp(target.localPosition, newPos, ref buttonVelocity, smoothTime);
            StartCoroutine(MoveRectPosition());
        }    
    }

    IEnumerator MoveRectPosition() {
        yield return new WaitForSeconds(3);
        target.localPosition = Vector3.SmoothDamp(target.localPosition, oldPos, ref buttonVelocity, smoothTime);
        hasTargetMoved = true;
    }
}
