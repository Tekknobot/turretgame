using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject player;
    public Transform firePoint;
    public Transform firePointUp;
    public Transform firePoint45;
    public GameObject projectile;

    public float fireRate = 20f;
    private float lastfired;                

    public bool canShoot = true;
    public bool flipRot = true;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && !player.GetComponent<CharacterController2D>().m_FacingRight) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("isShooting", true);
            Shoot();
        } 
        else if (Input.GetButton("Fire1") && player.GetComponent<CharacterController2D>().m_FacingRight) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("isShooting", true);
            Shoot();    
        }
        else {
            animator.SetBool("isShooting", false);
        }

        if (Input.GetButton("Jump")) {
            animator.SetBool("isShootingUp", true);
            animator.SetBool("isShooting", false);
            transform.rotation = Quaternion.Euler(0, 0, 90);
            ShootUp();
        }
        else {
            animator.SetBool("isShootingUp", false);
        }

        if (Input.GetButton("Fire2") && player.GetComponent<CharacterController2D>().m_FacingRight) {
            transform.rotation = Quaternion.Euler(0, 0, 45);
            animator.SetBool("isShooting45", true);
            Shoot45();
        }
        else if (Input.GetButton("Fire3") && !player.GetComponent<CharacterController2D>().m_FacingRight) {
            transform.rotation = Quaternion.Euler(0, 0, 135);
            animator.SetBool("isShooting45", true);
            Shoot45();
        }
        else {
            animator.SetBool("isShooting45", false);
        }        
    }

    void Shoot() {
        if (Time.time - lastfired > 1 / fireRate)
        {
            lastfired = Time.time;
            Instantiate(projectile, firePoint.transform.position, transform.rotation);
        }
    }

    void ShootUp() {
        if (Time.time - lastfired > 1 / fireRate) {
            lastfired = Time.time;
            Instantiate(projectile, firePointUp.transform.position, transform.rotation);
        }
    }    

    void Shoot45() {
        if (Time.time - lastfired > 1 / fireRate) {
            lastfired = Time.time;
            Instantiate(projectile, firePoint45.transform.position, transform.rotation);
        }
    }       
}
