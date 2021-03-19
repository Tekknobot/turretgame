using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 1;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Boss" || col.tag == "Crit") {
            Target enemy = col.GetComponent<Target>();
            if (enemy != null)
            {
                cam.GetComponent<CameraShake>().shakecamera();
                enemy.TakeDamage(damage);
            }
        }     

        if (col.tag == "Enemy") {
            TargetEnemy enemy = col.GetComponent<TargetEnemy>();
            if (enemy != null)
            {
                cam.GetComponent<CameraShake>().shakecamera();
                enemy.TakeDamage(damage);
            }
        }              
        Destroy(gameObject);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }        
}
