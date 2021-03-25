using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public GameObject health;
    public GameObject om;
    public GameObject arrow;

    public void LootChance()
    {
        if(Random.Range(0f, 1f) <= m_healthChance ) {
            Instantiate(health, transform.position, Quaternion.identity);
        }

        if(Random.Range(0f, 1f) <= m_omChance ) {
            Instantiate(om, transform.position, Quaternion.identity);
        }

        if(Random.Range(0f, 1f) <= m_arrowChance ) {
            Instantiate(om, transform.position, Quaternion.identity);
        }        
    }

    const float m_healthChance = 0.10f / 10f;             // Set odds here - e.g. 1 in 10 chance   
    const float m_omChance = 0.20f / 10f; 
    const float m_arrowChance = 0.20f / 10f; 
}
