using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    //public HealthBar healthBar; 
    //public GameObject bossBar;

    public int maxHealth = 100;
	public int currentHealth;
    
    public GameObject explosionPrefab; 
	public GameObject explosionEmitter;

    //public GameObject primaryTurret;

    public float pieceCount = 12f;   
    bool explosionTaskStarted = false; 
    public Vector3 deathPosition;

    public Text hitPointsText;

    public GameObject nextBoss;

    void Start() {
		currentHealth = maxHealth;
		//healthBar.SetMaxHealth(maxHealth);

        //GetComponent<ObjectOscillator>().enabled = true;        
        //GetComponent<BoxCollider2D>().enabled = true;
    }

    void Update() {
        float curHealthFloat = currentHealth;

        if (gameObject.tag != "Crit") {
            hitPointsText.text = Mathf.Round((curHealthFloat/maxHealth) * 100) + "%";

            if ((curHealthFloat/maxHealth) * 100 <= 75f) {
                hitPointsText.color = Color.yellow;
            }
            if ((curHealthFloat/maxHealth) * 100 <= 25f) {
                hitPointsText.color = Color.red;
            }  
        }          
    }

    public void TakeDamage (int amount)
    {
        currentHealth -= amount;
        //healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0f && explosionTaskStarted == false)
        {
            if (gameObject.tag == "Crit") {
                GameObject newObject = Instantiate(explosionPrefab, explosionEmitter.transform.position, Quaternion.identity) as GameObject;  // instatiate the object
                newObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                newObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
                Destroy(gameObject);
                return;
            }
            deathPosition = transform.position;
            InstantiateCircle();
            explosionTaskStarted = true;
            currentHealth = 0;
        }
    }

    void InstantiateCircle () 
    {
        StartCoroutine(ExplosionTask());
    }

    void GetObject()
    {
        GetComponent<ObjectOscillator>().enabled = false;
        GetComponent<SmoothFollow>().enabled = false;
        GetComponent<FireBullets>().enabled = false;
    }

    void Death()
    {       
        //GetComponent<LootDrop>().LootChance();
        Instantiate(explosionPrefab, explosionEmitter.transform.position, Quaternion.identity);
        if (nextBoss) {
            nextBoss.SetActive(true);
            this.gameObject.GetComponent<FireBullets>().CancelInvoke();
            Destroy(gameObject);
        }
        else {
            this.gameObject.GetComponent<FireBullets>().CancelInvoke();
            Destroy(gameObject);            
        }
    }

    IEnumerator ExplosionTask() {
        GetObject();
        for (int i = 0; i < pieceCount; i++)
        {
            /* Distance around the circle */  
            var radians = 2 * Mathf.PI / pieceCount * i;

            /* Get the vector direction */ 
            var vertical = Mathf.Sin(radians);
            var horizontal = Mathf.Cos(radians);

            var spawnDir = new Vector3 (horizontal, 0, vertical);

            /* Get the spawn position */ 
            var spawnPos = transform.position + spawnDir * 3f; // Radius is just the distance away from the point
            
            Instantiate(explosionPrefab, spawnPos, Quaternion.identity);
            GetComponent<DaShake>().shaketrue = true;
            yield return new WaitForSeconds(0.2f);
        }    
        Death();    
    }
}
