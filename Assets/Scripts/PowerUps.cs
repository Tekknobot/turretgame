using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    public GameObject rapidFireSFX;
    public GameObject normalFireSFX;

    public float powerUpTime = 0;
    bool hasPowerup = false;

    public Text omStatusText;

    // Start is called before the first frame update
    void Start()
    {
        omStatusText = GameObject.Find("OmStatus").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Update()
    {
        if(hasPowerup)
        {
            powerUpTime -= Time.deltaTime;
            if(powerUpTime <= 0)
            {
                powerUpTime = 0;
                Instantiate(normalFireSFX, transform.position, Quaternion.identity);
                hasPowerup = false;
            }
        }
        
        omStatusText.text = Mathf.Round((powerUpTime)) + " rapid fire";          
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
    }

    IEnumerator DefaultFireRate(Collider2D col) {
        yield return new WaitUntil(() => powerUpTime <= 0);
        GetComponent<SpriteRenderer>().material.SetColor("_FlashColor", Color.red);
        GetComponent<flash>().flashDuration = 0.1f;   
       
        hasPowerup = false;       
        transform.GetChild(2).gameObject.GetComponent<Shooting>().fireRate = 5f;            
    }    
}
