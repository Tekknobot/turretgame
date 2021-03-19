using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 10;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D col) {
		TargetPlayer player = col.GetComponent<TargetPlayer>();
		if (player != null)
		{
			player.TakeDamagePlayer(damage);
		}      
        GameObject newObject = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;  // instatiate the object
        newObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        GetComponent<LootDrop>().LootChance();   
        Destroy(gameObject);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
