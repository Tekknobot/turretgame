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

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            Button playbtn = playButton.GetComponent<Button>();
            playbtn.onClick.AddListener(PlayOnClick);

            Button quitbtn = quitButton.GetComponent<Button>();
            quitbtn.onClick.AddListener(QuitOnClick);        
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<TargetPlayer>().currentHealth <= 0 && SceneManager.GetActiveScene().buildIndex == 1) {
            LoadNextLevel();
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

    void PlayOnClick(){
        LoadFirstLevel();
    }      

    void QuitOnClick(){
        Application.Quit();
    }         

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
