using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class dialogHolder : MonoBehaviour {

    public string Dialog;
    private DialogueManager dManage;

    public string[] dialogueLines;

	// Use this for initialization
	void Start () {
        dManage = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButton("interact"))
        {
            Debug.Log("Interact");
        }
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "player")
        {
            //Debug.Log("Dialog Touch");
            if (CrossPlatformInputManager.GetButton("interact"))
            {
                //dManage.ShowBox(Dialog);
                Debug.Log("Interact");
                if (!dManage.dialogueActive)
                {
                    dManage.dialogLines = dialogueLines;
                    dManage.currentLine = 0;
                    dManage.ShowDialogue();

                    if(transform.parent.GetComponent<NpcController>() != null)
                    {
                        transform.parent.GetComponent<NpcController>().canMove = false;
                    }
                }
            }
        }
    }
}
