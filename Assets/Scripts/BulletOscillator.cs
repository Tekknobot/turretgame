using UnityEngine;
using System.Collections;
 
public class BulletOscillator : MonoBehaviour {
     
    public float speedMult = 1.0f;
    public float rangeMult = 1.0f;
    float basex = 0.0f;
    float elapsedTime = 0;
    
    // Update is called once per frame
    void Start() {
        basex = transform.position.x;
    }
    void Update () {
        Vector3 position = transform.position;
        elapsedTime += Time.deltaTime;
        float interval = Mathf.Sin(elapsedTime * (speedMult / rangeMult)) * rangeMult;    
        position.x = basex + interval;
        transform.position = position;
    }
}