using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : MonoBehaviour
{
    public GameObject target;
    private SpriteRenderer spriteRenderer;
    public bool markerLeft;
    public bool markerMiddle;
    public bool markerRight;

    // Start is called before the first frame update
    public void Awake() {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        this.spriteRenderer.flipX = target.transform.position.x < this.transform.position.x;
    }   

    void OnTriggerEnter2D(Collider2D col) {   
        if(col.tag == "MechMarker" && col.name == "MechLeft") {
            markerLeft = true;
        }  

        if(col.tag == "MechMarker" && col.name == "MechMiddle") {
            markerMiddle = true;
        } 

        if(col.tag == "MechMarker" && col.name == "MechRight") {
            markerRight = true;
        }                 
    }   

    void OnTriggerExit2D(Collider2D col) {   
        if(col.tag == "MechMarker" && col.name == "MechLeft") {
            markerLeft = false;
        }  

        if(col.tag == "MechMarker" && col.name == "MechMiddle") {
            markerMiddle = false;
        } 

        if(col.tag == "MechMarker" && col.name == "MechRight") {
            markerRight = false;
        }                 
    }      
}
