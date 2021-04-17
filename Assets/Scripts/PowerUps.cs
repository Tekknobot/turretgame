using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    public GameObject rapidFireSFX;
    public GameObject normalFireSFX;
    public GameObject multiFireSFX;

    public GameObject item;
    public GameObject itemEmitter;

    public float powerUpTime = 0;
    public float multiFireTime = 0;
    public bool hasPowerup = false;
    public bool hasArrow = false;

    public Text omStatusText;
    public Text arrowStatusText;
    public Text streakStatusText; 
    public Text streakCount;

    public GameObject dialogueManager;

    float varTime;
    public int continues;  

    // Start is called before the first frame update
    void Start()
    {
        omStatusText = GameObject.Find("OmStatus").GetComponent<Text>();
        arrowStatusText = GameObject.Find("ArrowStatus").GetComponent<Text>();
        streakStatusText = GameObject.Find("StreakStatus").GetComponent<Text>();
        streakCount = GameObject.Find("StreakCount").GetComponent<Text>();
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
        omStatusText.text = Mathf.Round((powerUpTime)) + " rapid";     

        if(hasArrow) {
            multiFireTime -= Time.deltaTime;
            if(multiFireTime <= 0)
            {
                multiFireTime = 0;
                hasArrow = false;
            }
        }
        arrowStatusText.text = Mathf.Round((multiFireTime)) + " multi"; 

        varTime += Time.deltaTime;
        streakStatusText.text = Mathf.Round((varTime)) + "/60"; 
        if(varTime > 60) {
            Instantiate(item, itemEmitter.transform.position, Quaternion.identity);
            varTime = 0;
        }        

        if(dialogueManager.GetComponent<DialogueManager>().sentences.Count >= 1) {
            varTime = 0;
        }

        streakCount.text = continues + " Stars";
    }

    void OnTriggerEnter2D(Collider2D col) {   
        if(col.tag == "Om") {
            powerUpTime += 16;
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
            multiFireTime += 16;
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

        if (col.tag == "EnemyBullet") {
            varTime = 0;
        }

        if (col.tag == "Star") {
            continues += 1;
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
