using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour
{
    public GameObject dialogueManager;
    public GameObject dialogueBox;

    public GameObject firstBoss;
    public GameObject secondBoss;
    public GameObject thirdBoss;
    public GameObject fourthBoss;
    public GameObject fifthBoss;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dialogue());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Dialogue() {
        yield return new WaitForSeconds(1);
        GetComponent<DialogueTrigger>().TriggerDialogue();
        yield return new WaitForSeconds(3);
        dialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(3);
        dialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(3);
        dialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(3);
        dialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(3);
        dialogueManager.GetComponent<DialogueManager>().EndDialogue();
        firstBoss.SetActive(true);
        yield return new WaitUntil(()=> !firstBoss);
        GetComponent<DialogueTrigger>().dialogue.sentences[0] = "Enemy is down!";
        GetComponent<DialogueTrigger>().dialogue.sentences[1] = "Great work! but there's more on the way!";
        GetComponent<DialogueTrigger>().dialogue.sentences[2] = "Get ready!";
        GetComponent<DialogueTrigger>().TriggerDialogue();
        yield return new WaitForSeconds(3);
        dialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(3);
        dialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(3);        
        dialogueManager.GetComponent<DialogueManager>().EndDialogue();
        secondBoss.SetActive(true);   
        yield return new WaitUntil(()=> !secondBoss);
        GetComponent<DialogueTrigger>().dialogue.sentences[0] = "Amazing work kid!";
        GetComponent<DialogueTrigger>().dialogue.sentences[1] = "You're in the zone.";
        GetComponent<DialogueTrigger>().dialogue.sentences[2] = "Keep going!";
        GetComponent<DialogueTrigger>().dialogue.sentences[3] = "We believe in you.";        
        GetComponent<DialogueTrigger>().TriggerDialogue();
        yield return new WaitForSeconds(3);
        dialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(3);
        dialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(3);        
        dialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(3);        
        dialogueManager.GetComponent<DialogueManager>().EndDialogue();        
        thirdBoss.SetActive(true);   
        yield return new WaitUntil(()=> !thirdBoss);
        GetComponent<DialogueTrigger>().dialogue.sentences[0] = "Hey, it looks like you can hold your own.";
        GetComponent<DialogueTrigger>().dialogue.sentences[1] = "But you're not out of the danger zone yet.";
        GetComponent<DialogueTrigger>().dialogue.sentences[2] = "Mechs incoming!!!";
        GetComponent<DialogueTrigger>().dialogue.sentences[3] = "Good luck.";        
        GetComponent<DialogueTrigger>().TriggerDialogue();
        yield return new WaitForSeconds(3);
        dialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(3);
        dialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(3);        
        dialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
        yield return new WaitForSeconds(3);        
        dialogueManager.GetComponent<DialogueManager>().EndDialogue();        
        fourthBoss.SetActive(true);              
             
    }
}
