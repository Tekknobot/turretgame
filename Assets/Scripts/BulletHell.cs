using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHell : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection; 

    public float repeatFire = 2f;
    public float orbMiniSpeed = 2f;

    public GameObject bulletPool;
    public GameObject bulletEmitter;

    public Transform transformLeft;
    public Transform transformMiddle;
    public Transform transformRight;
    public Transform transformTop;
    public Transform transformBottom;    

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.transform.name == "RadialBulletSpawner") {
            StartCoroutine(RadialBulletHell());           
        } 

        if(gameObject.transform.name == "SingleBulletSpawner") {
            StartCoroutine(SingleBulletHell());           
        }             
    }

    void Update() {

    }

    private void Fire() {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++) {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                if (bulletEmitter == null) {
                    bul.transform.position = transform.position;
                    bul.transform.rotation = transform.rotation;                
                }
                else {
                    bul.transform.position = bulletEmitter.transform.position;
                    bul.transform.rotation = bulletEmitter.transform.rotation;
                }
                bul.SetActive(true);
                bul.GetComponent<Orb_mini>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
    }    

    IEnumerator RadialBulletHell() {
        InvokeRepeating("Fire", 0f, repeatFire);
        yield return new WaitForSeconds(0);              
    }        

    IEnumerator SingleBulletHell() {
        InvokeRepeating("Fire", 0f, repeatFire);
        yield return new WaitForSeconds(0);
    } 
}
