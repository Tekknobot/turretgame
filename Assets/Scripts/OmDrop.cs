using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmDrop : MonoBehaviour
{
    public GameObject rapidFireSFX;
    public GameObject normalFireSFX;

    public float powerUpTime = 0;
    static bool hasPowerup = false;

    Coroutine PowerUpCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        //hasPowerup = false;
    }

    void OnTriggerEnter2D(Collider2D col) {   
        if(col.tag == "Player" && hasPowerup == false) {
            hasPowerup = true;
            transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            col.transform.GetChild(2).gameObject.GetComponent<Shooting>().fireRate = 10f;
            col.GetComponent<SpriteRenderer>().material.SetColor("_FlashColor", Color.white);
            col.GetComponent<flash>().flashDuration = 1f; 
            col.GetComponent<flash>().Flash();           
            Instantiate(rapidFireSFX, transform.position, Quaternion.identity);
            powerUpTime += 10;
            if (PowerUpCoroutine == null) {    
                PowerUpCoroutine = StartCoroutine(DefaultFireRate(col));
            }    
        }  
    }

    IEnumerator DefaultFireRate(Collider2D col) {
        yield return new WaitForSeconds(1);
        col.GetComponent<SpriteRenderer>().material.SetColor("_FlashColor", Color.red);
        col.GetComponent<flash>().flashDuration = 0.1f;   

        while (powerUpTime > 0) {
            powerUpTime = powerUpTime - 1 * Time.deltaTime;
            yield return null;
        }    

        hasPowerup = false;

        PowerUpCoroutine = null;
        powerUpTime = 0;
       
        col.transform.GetChild(2).gameObject.GetComponent<Shooting>().fireRate = 5f;        
        Instantiate(normalFireSFX, transform.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);    
    }
}
