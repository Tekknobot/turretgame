using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject player;
    public Animator transition;
    public float transitionTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<TargetPlayer>().currentHealth <= 0 && SceneManager.GetActiveScene().buildIndex != 1) {
            LoadNextLevel();
        }

        if (Input.GetButtonDown("Fire1") && SceneManager.GetActiveScene().buildIndex == 1) {
            LoadFirstLevel();
        }
    }

    public void ReloadLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }   

    public void LoadFirstLevel() {
        StartCoroutine(LoadLevel(0));
    }     

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
