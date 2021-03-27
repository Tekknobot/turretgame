using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour
{
    public GameObject dialogueManager;
    public GameObject dialogueBox;
    bool hasDialogueStarted = false;

    public GameObject firstBoss;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CommanderDialogue());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CommanderDialogue() {
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
    }
}
