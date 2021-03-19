using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection; 

    public float repeatFire = 2f;  
    public float repeatBomb = 0.1f;
    public float repeatEnemy = 15f;

    public GameObject Orb;
    public float duration = 15;
    public GameObject bulletPool;
    public float orbMiniSpeed = 2f;

    public GameObject missile;

    public GameObject spawnLeft;
    public GameObject spawnRight;

    public GameObject Enemy;

    public Transform mechLeft;
    public Transform mechMiddle;
    public Transform mechRight;

    public GameObject skyDrop;
    public GameObject skyDropEmitter;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Transform>().tag == "Boss" && this.name != "Alpha" && this.name != "Mech") {
            StartCoroutine(DropBombs());
        }

        if (GetComponent<Transform>().tag == "Enemy") {
            StartCoroutine(DropBombsEnemy());
        }

        if (this.name == "Alpha" && GetComponent<Transform>().tag == "Boss") {
            StartCoroutine(DropBombsAlpha());
        }   

        if (this.name == "Mech" && GetComponent<Transform>().tag == "Boss") {
            StartCoroutine(DropBombsMech());
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
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Orb_mini>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
    }

    private void Drop() {
        Instantiate(Orb, transform.position, Quaternion.identity);
    }

    private void Missile() {
        Instantiate(missile, spawnLeft.transform.position, Quaternion.identity);
        Instantiate(missile, spawnRight.transform.position, Quaternion.identity);
    }    

    private void DropEnemy() {
        Instantiate(Enemy, transform.position, Quaternion.identity);
    }

    IEnumerator DropBombs() {
        InvokeRepeating("Drop", 0f, repeatBomb);
        yield return new WaitForSeconds(duration);
        CancelInvoke("Drop");
        GetComponent<ObjectOscillator>().enabled = false;
        InvokeRepeating("Fire", 0f, repeatFire);
        InvokeRepeating("Missile", 0f, repeatFire);
        bulletPool.GetComponent<BulletPool>().orbMiniSpeed = orbMiniSpeed;
        
        yield return new WaitForSeconds(duration);
        CancelInvoke("Fire");
        CancelInvoke("Missile");
        GetComponent<ObjectOscillator>().enabled = true;        
        InvokeRepeating("Drop", 0f, repeatBomb);
        
        yield return new WaitForSeconds(duration);
        CancelInvoke("Drop");
        GetComponent<ObjectOscillator>().enabled = true;
        InvokeRepeating("Fire", 0f, repeatFire);
        bulletPool.GetComponent<BulletPool>().orbMiniSpeed = orbMiniSpeed;
        
        yield return new WaitForSeconds(duration);
        CancelInvoke("Fire");      
        StartCoroutine(DropBombs());
    }

    IEnumerator DropBombsEnemy() {
        InvokeRepeating("Fire", 0f, repeatFire);
        GameObject.Find("BulletPool").GetComponent<BulletPool>().orbMiniSpeed = orbMiniSpeed;
        yield return null;
    }    

    IEnumerator DropBombsAlpha() {
        GetComponent<ObjectOscillator>().enabled = false;
        GetComponent<FireBullets>().repeatFire = 0;
        GetComponent<FireBullets>().repeatBomb = 0;
        InvokeRepeating("DropEnemy", 0f, repeatEnemy);
        InvokeRepeating("Missile", 0f, repeatFire);
        yield return new WaitForSeconds(duration);
        CancelInvoke("DropEnemy");
        CancelInvoke("Missile");
        GetComponent<ObjectOscillator>().enabled = true;
        GetComponent<FireBullets>().repeatFire = 1;
        GetComponent<FireBullets>().repeatBomb = 0.3f;
        InvokeRepeating("Fire", 0f, repeatFire);   
        yield return new WaitForSeconds(duration);     
        CancelInvoke("Fire"); 
        InvokeRepeating("Drop", 0f, repeatBomb);
        yield return new WaitForSeconds(duration);
        CancelInvoke("Drop");
        StartCoroutine(DropBombsAlpha());
    }      

    IEnumerator DropBombsMech() {        
        yield return new WaitForSeconds(3);
        InvokeRepeating("Fire", 0f, repeatFire);    
        GetComponent<SmoothFollow>().enabled = true;  
        GetComponent<SmoothFollow>().dampTime = 0.5f;
        GetComponent<SmoothFollow>().target = mechLeft; 
        yield return new WaitUntil(() => GetComponent<Mech>().markerLeft == true);
        yield return new WaitForSeconds(3); 
        GetComponent<SmoothFollow>().enabled = true;  
        GetComponent<SmoothFollow>().dampTime = 0.5f;
        GetComponent<SmoothFollow>().target = mechRight;     
        yield return new WaitUntil(() => GetComponent<Mech>().markerRight == true);  
        yield return new WaitForSeconds(3);
        GetComponent<SmoothFollow>().enabled = true;  
        GetComponent<SmoothFollow>().dampTime = 0.5f;
        GetComponent<SmoothFollow>().target = mechMiddle;     
        yield return new WaitUntil(() => GetComponent<Mech>().markerMiddle == true); 
        CancelInvoke("Fire");
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().material.SetColor("_FlashColor", Color.black);
        GetComponent<flash>().flashDuration = 9f; 
        GetComponent<flash>().Flash();         
        Instantiate(skyDrop, skyDropEmitter.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(9);
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().material.SetColor("_FlashColor", Color.white);
        GetComponent<flash>().flashDuration = 0.1f;  
        GameObject.FindGameObjectWithTag("SkyDrop").GetComponent<SkyDrop>().CancelInvoke("StartSkyDrop");      
        GameObject[] skyDrops = GameObject.FindGameObjectsWithTag("SkyDrop");
        foreach(GameObject skyDropObject in skyDrops)
        GameObject.Destroy(skyDropObject);
        StartCoroutine(DropBombsMech());             
    }       
}
