using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActionCode2D.Renderers;

 public class DashAbility : MonoBehaviour {
 
    public float moveDirection;
 
    public const float maxDashTime = 1.0f;
    public float dashStoppingSpeed = 0.1f;
    float currentDashTime = maxDashTime;
    public float dashSpeed = 6;
    CharacterController2D controller;
 
    public GameObject dashSFX;    
 
    private void Awake()
    {
        controller = GetComponent<CharacterController2D>();
    }
 
    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("RightBumper")) //Right bumper button
        {
            currentDashTime = 0;
            GetComponent<PlayerMovement>().enabled = false;
            Instantiate(dashSFX, transform.position, Quaternion.identity);
            GetComponent<CircleCollider2D>().enabled = false; 
            GetComponent<Rigidbody2D>().gravityScale = 0;                           
        }
    }

    void FixedUpdate() {
        if(currentDashTime < maxDashTime)
        {
            moveDirection = Input.GetAxisRaw("Horizontal") * dashSpeed;
            currentDashTime += dashStoppingSpeed;
        }
        else
        {
            moveDirection = 0;
            currentDashTime = 0;
            GetComponent<PlayerMovement>().enabled = true; 
            GetComponent<CircleCollider2D>().enabled = true;
            GetComponent<Rigidbody2D>().gravityScale = 1;         
        }    

        controller.Move(moveDirection * Time.fixedDeltaTime, false, false);    
    }
}     
