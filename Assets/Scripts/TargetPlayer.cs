﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TargetPlayer : MonoBehaviour
{
    //public HealthBar healthBar;

    public int maxHealth = 100;
	public int currentHealth;  

    public float pieceCount = 12f; 

    public Vector3 deathPosition;
    public GameObject explosion;

    public Text hitPointsText;
    public float curHealthFloat;

    void Start() {
		currentHealth = maxHealth;
		//healthBar.SetMaxHealth(maxHealth);
    }

    void Update() {
        curHealthFloat = currentHealth;
        hitPointsText.text = Mathf.Round((curHealthFloat/maxHealth) * 100) + "%";

        if ((curHealthFloat/maxHealth) * 100 <= 75f) {
            hitPointsText.color = Color.yellow;
        }
        if ((curHealthFloat/maxHealth) * 100 <= 25f) {
            hitPointsText.color = Color.red;
        } 
        if ((curHealthFloat/maxHealth) * 100 >= 75f) {
            hitPointsText.color = Color.white;
        }         

        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
    }

    public void TakeDamagePlayer (int amount)
    {
        currentHealth -= amount;
        GetComponent<flash>().Flash();
        //healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0f)
        {
            StartCoroutine(Wait());
        }
    }

    void Death()
    {     
        Instantiate(explosion, transform.position, Quaternion.identity);    
        Destroy(gameObject);    
    }

    IEnumerator Wait() {
        currentHealth = 0;
        yield return new WaitForSeconds(0.1f);
        Death();
    }
}
