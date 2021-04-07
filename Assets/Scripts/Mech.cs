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
    public bool markerTop;
    public bool markerBottom;    

    // Start is called before the first frame update
    public void Awake() {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.x < this.transform.position.x) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
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

        if(col.tag == "MechMarker" && col.name == "MechTop") {
            markerTop = true;
        } 

        if(col.tag == "MechMarker" && col.name == "MechBottom") {
            markerBottom = true;
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

        if(col.tag == "MechMarker" && col.name == "MechTop") {
            markerTop = false;
        } 

        if(col.tag == "MechMarker" && col.name == "MechBottom") {
            markerBottom = false;
        }                        
    }      
}
