using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    public GameObject rapidFireSFX;
    public GameObject normalFireSFX;
    public GameObject multiFireSFX;

    public float powerUpTime = 0;
    public float multiFireTime = 0;
    public bool hasPowerup = false;
    public bool hasArrow = false;

    public Text omStatusText;
    public Text arrowStatusText;

    // Start is called before the first frame update
    void Start()
    {
        omStatusText = GameObject.Find("OmStatus").GetComponent<Text>();
        arrowStatusText = GameObject.Find("ArrowStatus").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Update()
    {
        if(hasPowerup) {
            powerUpTime -= Time.deltaTime;
            if(powerUpTime <= 0)
            {
                powerUpTime = 0;
                Instantiate(normalFireSFX, transform.position, Quaternion.identity);
                hasPowerup = false;
            }
        }
        omStatusText.text = Mathf.Round((powerUpTime)) + " rapid fire";     

        if(hasArrow) {
            multiFireTime -= Time.deltaTime;
            if(multiFireTime <= 0)
            {
                multiFireTime = 0;
                hasArrow = false;
            }
        }
        arrowStatusText.text = Mathf.Round((multiFireTime)) + " multi fire";             
    }

    void OnTriggerEnter2D(Collider2D col) {   
        if(col.tag == "Om") {
            powerUpTime += 8;
            hasPowerup = true;
            col.transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            col.transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = false;            
            transform.GetChild(2).gameObject.GetComponent<Shooting>().fireRate = 10f;
            GetComponent<SpriteRenderer>().material.SetColor("_FlashColor", Color.white);
            GetComponent<flash>().flashDuration = 1f; 
            GetComponent<flash>().Flash();           
            Instantiate(rapidFireSFX, transform.position, Quaternion.identity);
            StartCoroutine(DefaultFireRate(col));    
        }  

        if(col.tag == "ArrowHead") {
            multiFireTime += 8;
            hasArrow = true;
            col.transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            col.transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = false;            
            GetComponent<SpriteRenderer>().material.SetColor("_FlashColor", Color.white);
            GetComponent<flash>().flashDuration = 1f; 
            GetComponent<flash>().Flash();   
            Instantiate(multiFireSFX, transform.position, Quaternion.identity);        
            StartCoroutine(DefaultFire(col));            
        }
    }

    IEnumerator DefaultFireRate(Collider2D col) {
        yield return new WaitUntil(() => powerUpTime <= 0);
        GetComponent<SpriteRenderer>().material.SetColor("_FlashColor", Color.red);
        GetComponent<flash>().flashDuration = 0.1f;   
       
        hasPowerup = false;       
        transform.GetChild(2).gameObject.GetComponent<Shooting>().fireRate = 5f;            
    } 

    IEnumerator DefaultFire(Collider2D col) {
        yield return new WaitUntil(() => multiFireTime <= 0);
        GetComponent<SpriteRenderer>().material.SetColor("_FlashColor", Color.red);
        GetComponent<flash>().flashDuration = 0.1f;     
        hasArrow = false;                  
    }       
}
