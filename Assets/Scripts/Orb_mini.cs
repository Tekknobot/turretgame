using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_mini : MonoBehaviour
{
    private Vector2 moveDirection;
    public float moveSpeed;

    public int damage = 10;
    public GameObject explosion;    

    private void OnEnable() {
        Invoke("Destroy", 10f);
    }

    // Start is called before the first frame update
    void Start()
    {
        //moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir) {
        moveDirection = dir;
    }

    private void Destroy() {
        gameObject.SetActive(false);
    }

    private void OnDisable() {
        CancelInvoke();
    }

    void OnTriggerEnter2D(Collider2D col) {
		TargetPlayer player = col.GetComponent<TargetPlayer>();
		if (player != null)
		{
			player.TakeDamagePlayer(damage);
		}      
        GameObject newObject = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;  // instatiate the object
        newObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);   
        Destroy();
    }    
}
