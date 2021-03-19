using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetEnemy : MonoBehaviour
{
    public int maxHealth = 100;
	public int currentHealth;
    
    public GameObject explosionPrefab; 
	public GameObject explosionEmitter;

    void Start() {
		currentHealth = maxHealth;
    }

    public void TakeDamage (int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0f)
        {
            if (gameObject.tag == "Enemy") {
                GameObject newObject = Instantiate(explosionPrefab, explosionEmitter.transform.position, Quaternion.identity) as GameObject;  // instatiate the object
                newObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                newObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
                Destroy(gameObject);
                return;
            }
        }
    }
}
