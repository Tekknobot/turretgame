using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;
    public float orbMiniSpeed = 2;

    [SerializeField]
    private GameObject pooledBullet;
    private bool notEnoughBulletsInPool = true;

    private List<GameObject> bullets;

    private void Awake() {
        bulletPoolInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet() {
        if (bullets.Count > 0) {
            for (int i = 0; i < bullets.Count; i++) {
                if (!bullets[i].activeInHierarchy) {
                    return bullets[i];
                }
            }
        }

        if (notEnoughBulletsInPool) {
            GameObject bul =  GameObject.Instantiate(pooledBullet, transform.position, Quaternion.identity) as GameObject;
            bul.GetComponent<Orb_mini>().moveSpeed = orbMiniSpeed;
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }

        return null;
    }
}
