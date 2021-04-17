using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject player;
    public Animator transition;
    public float transitionTime = 1;

    public Button playButton;
    public Button quitButton;

    public GameObject star;
    public GameObject continueSFX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<TargetPlayer>().currentHealth <= 0 && player.GetComponent<PowerUps>().continues <= 0 && SceneManager.GetActiveScene().buildIndex == 1) {
            LoadNextLevel();
        }
        
        if (player.GetComponent<TargetPlayer>().currentHealth <= 0 && player.GetComponent<PowerUps>().continues >= 1) {
            player.GetComponent<TargetPlayer>().currentHealth = 50;
            player.GetComponent<PowerUps>().continues -= 1;
            GameObject continueStar = Instantiate(star, player.transform.position + new Vector3(0,1,0), Quaternion.identity) as GameObject;
            continueStar.GetComponent<Rigidbody2D>().gravityScale = -1;
            Instantiate(continueSFX, transform.position, Quaternion.identity);
        }

        if (Input.GetButtonDown("Fire1") && SceneManager.GetActiveScene().buildIndex == 2) {
            LoadMenuLevel();
        }        
    }

    public void ReloadLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }   

    public void LoadFirstLevel() {
        StartCoroutine(LoadLevel(1));
    }   

    public void LoadMenuLevel() {
        StartCoroutine(LoadLevel(0));
    }    

    public void QuitOnClick(){
        Application.Quit();
    }         

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
