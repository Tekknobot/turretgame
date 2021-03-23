using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMusic : MonoBehaviour
{
    public AudioClip song1;
    public AudioClip song2;
    public AudioClip song3;
    public AudioClip song4;
    public AudioClip song5;

    public GameObject bomber;
    public GameObject pharaoh;
    public GameObject alpha;
    public GameObject mech;
    public GameObject lunatic;

    bool songChanged0 = false;
    bool songChanged1 = false;
    bool songChanged2 = false;
    bool songChanged3 = false;
    bool songChanged4 = false;
    bool songChanged5 = false;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<CrossFadeMusicManager>().ChangeSong(song1);
    }

    // Update is called once per frame
    void Update()
    {
        if (songChanged0 == false) {
            if (bomber.activeSelf) {
                GetComponent<CrossFadeMusicManager>().ChangeSong(song1);
                songChanged0 = true;
            }
        }

        if (songChanged1 == false) {
            if (pharaoh.activeSelf) {
                GetComponent<CrossFadeMusicManager>().ChangeSong(song2);
                songChanged1 = true;
            }
        }

        if (songChanged2 == false) {
            if (alpha.activeSelf) {
                GetComponent<CrossFadeMusicManager>().ChangeSong(song3);
                songChanged2 = true;
            }
        }

        if (songChanged3 == false) {
            if (mech.activeSelf) {
                GetComponent<CrossFadeMusicManager>().ChangeSong(song4);
                songChanged3 = true;
            }
        }  

        if (songChanged4 == false) {
            if (lunatic.activeSelf) {
                GetComponent<CrossFadeMusicManager>().ChangeSong(song5);
                songChanged4 = true;
            }
        }                    
    }
}
