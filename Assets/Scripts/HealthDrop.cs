using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    public int healthAmount;
    public GameObject sfx;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D col) {   
        if(col.tag == "Player") {
            col.GetComponent<TargetPlayer>().currentHealth += healthAmount;
            transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            col.GetComponent<SpriteRenderer>().material.SetColor("_FlashColor", Color.white);
            col.GetComponent<flash>().flashDuration = 1f; 
            col.GetComponent<flash>().Flash();           
            StartCoroutine(DefaultFlash(col)); 
        }  
    }

    IEnumerator DefaultFlash(Collider2D col) {
        yield return new WaitForSeconds(1);
        col.GetComponent<SpriteRenderer>().material.SetColor("_FlashColor", Color.red);
        col.GetComponent<flash>().flashDuration = 0.1f;
        Instantiate(sfx, transform.position, Quaternion.identity); 
        Destroy(transform.parent.gameObject);           
    }    
}
