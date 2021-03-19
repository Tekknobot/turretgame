using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;    
        
        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        if (Input.GetButtonDown("Fire1")) {
            jump = true;
            //animator.SetBool("Jump", true);
        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
 
        if(screenPos.x < 0){
            print("Left bounds");
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
        else if(screenPos.x > Screen.width) {
            print("Right bounds");
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }       
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void OnLanding() {
        //animator.SetBool("Jump", false);
    }
}
