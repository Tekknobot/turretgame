using UnityEngine;
using System.Collections;
 
public class SmoothFollow : MonoBehaviour {
     
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
 
    void Start() {
        if (GetComponent<Transform>().tag == "Enemy") {
            target = GameObject.Find("EnemyPoint").GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update () 
    {
        if (target)
        {
            Vector3 point = transform.position;
            Vector3 delta = target.position - transform.position;
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}