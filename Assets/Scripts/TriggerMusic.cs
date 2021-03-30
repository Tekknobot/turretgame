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
    public AudioClip song6;
    public AudioClip surfSFX;

    public GameObject bomber;
    public GameObject pharaoh;
    public GameObject alpha;
    public GameObject mech;
    public GameObject lunatic;
    public GameObject mechZilla;    

    public bool surfIsPlaying = false;
    public bool songChanged0 = false;
    public bool songChanged1 = false;
    public bool songChanged2 = false;
    public bool songChanged3 = false;
    public bool songChanged4 = false;
    public bool songChanged5 = false;    

    public GameObject DangerUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (surfIsPlaying == false) {
            GetComponent<CrossFadeMusicManager>().ChangeSong(surfSFX);
            surfIsPlaying = true;
        }

        if (songChanged0 == false) {
            if (bomber.activeSelf) {
                GetComponent<CrossFadeMusicManager>().ChangeSong(song1);
                DangerUI.GetComponent<MoveRect>().hasTargetMoved = false;
                songChanged0 = true;
                StartCoroutine(WaitforDangerUI());
            }
        }

        if (songChanged1 == false) {
            if (pharaoh.activeSelf) {
                GetComponent<CrossFadeMusicManager>().ChangeSong(song2);
                DangerUI.GetComponent<MoveRect>().hasTargetMoved = false;
                songChanged1 = true;
                StartCoroutine(WaitforDangerUI());
            }
        }

        if (songChanged2 == false) {
            if (alpha.activeSelf) {
                GetComponent<CrossFadeMusicManager>().ChangeSong(song3);
                DangerUI.GetComponent<MoveRect>().hasTargetMoved = false;
                songChanged2 = true;
                StartCoroutine(WaitforDangerUI());
            }
        }

        if (songChanged3 == false) {
            if (mech.activeSelf) {
                GetComponent<CrossFadeMusicManager>().ChangeSong(song4);
                DangerUI.GetComponent<MoveRect>().hasTargetMoved = false;
                songChanged3 = true;
                StartCoroutine(WaitforDangerUI());
            }
        }  

        if (songChanged4 == false) {
            if (lunatic.activeSelf) {
                GetComponent<CrossFadeMusicManager>().ChangeSong(song5);
                DangerUI.GetComponent<MoveRect>().hasTargetMoved = false;
                songChanged4 = true;
                StartCoroutine(WaitforDangerUI());
            }
        }    

        if (songChanged5 == false) {
            if (mechZilla.activeSelf) {
                GetComponent<CrossFadeMusicManager>().ChangeSong(song6);
                DangerUI.GetComponent<MoveRect>().hasTargetMoved = false;
                songChanged5 = true;
                StartCoroutine(WaitforDangerUI());
            }
        }  
    }

    IEnumerator WaitforDangerUI() {
        yield return new  WaitForSeconds(3);
        DangerUI.GetComponent<MoveRect>().hasTargetMoved = true;
    }
}
