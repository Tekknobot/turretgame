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

    public Animator animator;

    float horizontalMove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Fire1") && !player.GetComponent<CharacterController2D>().m_FacingRight) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            player.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("isShooting", true);
            Shoot();
        } 
        else if (Input.GetButton("Fire1") && player.GetComponent<CharacterController2D>().m_FacingRight) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            player.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
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
            player.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            ShootUp();
        }
        else {
            animator.SetBool("isShootingUp", false);
        }

        if (Input.GetButton("Fire2") && player.GetComponent<CharacterController2D>().m_FacingRight && horizontalMove == 0) {
            transform.rotation = Quaternion.Euler(0, 0, 45);
            player.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("isShooting45", true);
            Shoot45();
        }
        else if (Input.GetButton("Fire3") && !player.GetComponent<CharacterController2D>().m_FacingRight && horizontalMove == 0) {
            transform.rotation = Quaternion.Euler(0, 0, 135);
            player.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("isShooting45", true);
            Shoot45();
        }
        else if (Input.GetButton("Fire2") && player.GetComponent<CharacterController2D>().m_FacingRight && horizontalMove > 0) {
            transform.rotation = Quaternion.Euler(0, 0, 45);
            player.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("isShooting45", true);
            Shoot45();
        }   
        else if (Input.GetButton("Fire3") && !player.GetComponent<CharacterController2D>().m_FacingRight && horizontalMove < 0) {
            transform.rotation = Quaternion.Euler(0, 0, 135);
            player.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("isShooting45", true);
            Shoot45();
        }                     
        else if (Input.GetButton("Fire2") && horizontalMove < 0) {
            transform.rotation = Quaternion.Euler(0, 0, 45);
            player.GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("isShooting45", true);
            Shoot45();
        }
        else if (Input.GetButton("Fire3") && horizontalMove > 0) {
            transform.rotation = Quaternion.Euler(0, 0, 135);
            player.GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("isShooting45", true);
            Shoot45();
        } 
        else if (Input.GetButton("Fire2") && horizontalMove == 0 && !player.GetComponent<CharacterController2D>().m_FacingRight) {
            transform.rotation = Quaternion.Euler(0, 0, 45);
            player.GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("isShooting45", true);
            Shoot45();
        }
        else if (Input.GetButton("Fire3") && horizontalMove == 0 && player.GetComponent<CharacterController2D>().m_FacingRight) {
            transform.rotation = Quaternion.Euler(0, 0, 135);
            player.GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("isShooting45", true);
            Shoot45();
        }        
        else {
            animator.SetBool("isShooting45", false);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            player.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
        }          
    }

    void Shoot() {
        if (Time.time - lastfired > 1 / fireRate)
        {
            lastfired = Time.time;
            Instantiate(projectile, firePoint.transform.position, transform.rotation);
            if (player.GetComponent<PowerUps>().hasArrow == true && !player.GetComponent<CharacterController2D>().m_FacingRight) {                
                Instantiate(projectile, firePoint.transform.position, Quaternion.Euler(0, 0, 190));
                Instantiate(projectile, firePoint.transform.position, Quaternion.Euler(0, 0, 170));
            }   
            else if (player.GetComponent<PowerUps>().hasArrow == true && player.GetComponent<CharacterController2D>().m_FacingRight) {              
                Instantiate(projectile, firePoint.transform.position, Quaternion.Euler(0, 0, 10));
                Instantiate(projectile, firePoint.transform.position, Quaternion.Euler(0, 0, 350));
            }                     
        }
    }

    void ShootUp() {
        if (Time.time - lastfired > 1 / fireRate) {
            lastfired = Time.time;
            Instantiate(projectile, firePointUp.transform.position, transform.rotation);
            if (player.GetComponent<PowerUps>().hasArrow == true) {
                Instantiate(projectile, firePointUp.transform.position, Quaternion.Euler(0, 0, 100));
                Instantiate(projectile, firePointUp.transform.position, Quaternion.Euler(0, 0, 80));
            }
        }
    }    

    void Shoot45() {
        if (Time.time - lastfired > 1 / fireRate) {
            lastfired = Time.time;
            Instantiate(projectile, firePoint45.transform.position, transform.rotation);
            if (Input.GetButton("Fire2") && player.GetComponent<PowerUps>().hasArrow == true) {                
                Instantiate(projectile, firePoint45.transform.position, Quaternion.Euler(0, 0, 55));
                Instantiate(projectile, firePoint45.transform.position, Quaternion.Euler(0, 0, 35));
            }  
            else if (Input.GetButton("Fire3") && player.GetComponent<PowerUps>().hasArrow == true) {                
                Instantiate(projectile, firePoint45.transform.position, Quaternion.Euler(0, 0, 145));
                Instantiate(projectile, firePoint45.transform.position, Quaternion.Euler(0, 0, 125));
            }                                                                
        }            
    }       
}
