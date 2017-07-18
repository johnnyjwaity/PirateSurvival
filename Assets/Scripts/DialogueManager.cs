using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public bool dialogueActive;

    public string[] dialogLines;
    public int currentLine;

    private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () {
        if (dialogueActive && Input.GetKeyUp(KeyCode.Space)) 
        {
            //dBox.SetActive(false);
            //dialogueActive = false;

            currentLine++;

        }
        if (currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogueActive = false;
            thePlayer.canMove = true;

            currentLine = 0;
        }
        dText.text = dialogLines[currentLine];
    }

    public void ShowBox(string dialog)
    {
        dialogueActive = true;
        dBox.SetActive(true);
        dText.text = dialog;
        thePlayer.canMove = false;
    }
    public void ShowDialogue()
    {
        dialogueActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
    }
}
