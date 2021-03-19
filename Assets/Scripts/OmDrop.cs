using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OmDrop : MonoBehaviour
{
    public GameObject rapidFireSFX;
    public GameObject normalFireSFX;

    public float powerUpTime = 0;
    static bool hasPowerup = false;

    Coroutine PowerUpCoroutine;

    public Text omStatusText;

    private static OmDrop omInstance;

    void Start() {
        omStatusText = GameObject.Find("OmStatus").GetComponent<Text>();
    }

    void OnTriggerEnter2D(Collider2D col) {   
        if(col.tag == "Player" && hasPowerup == false) {
            hasPowerup = true;
            powerUpTime += 8;
            transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            col.transform.GetChild(2).gameObject.GetComponent<Shooting>().fireRate = 10f;
            col.GetComponent<SpriteRenderer>().material.SetColor("_FlashColor", Color.white);
            col.GetComponent<flash>().flashDuration = 1f; 
            col.GetComponent<flash>().Flash();           
            Instantiate(rapidFireSFX, transform.position, Quaternion.identity);
            StartCoroutine(DefaultFireRate(col));    
        }  
    }

    IEnumerator DefaultFireRate(Collider2D col) {
        yield return new WaitUntil(() => powerUpTime <= 0);
        col.GetComponent<SpriteRenderer>().material.SetColor("_FlashColor", Color.red);
        col.GetComponent<flash>().flashDuration = 0.1f;   
       
        hasPowerup = false;       
        col.transform.GetChild(2).gameObject.GetComponent<Shooting>().fireRate = 5f;        
        Instantiate(normalFireSFX, transform.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);    
    }
}
