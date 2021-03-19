using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public GameObject health;
    public GameObject om;

    public void LootChance()
    {
        if(Random.Range(0f, 1f) <= m_healthChance ) {
            // spawn a dropped item
            Instantiate(health, transform.position, Quaternion.identity);
        }

        if(Random.Range(0f, 1f) <= m_omChance ) {
            // spawn a dropped item
            Instantiate(om, transform.position, Quaternion.identity);
        }
    }

    const float m_healthChance = 0.20f / 10f;             // Set odds here - e.g. 1 in 10 chance   
    const float m_omChance = 0.20f / 10f; 
}
