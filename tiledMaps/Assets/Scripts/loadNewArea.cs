using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loadNewArea : MonoBehaviour {

    public string leveltoload;

    public string exitPoint;

    private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.name == "player")
        {
            //SceneManager.LoadScene(leveltoload);
            UnityEngine.SceneManagement.SceneManager.LoadScene(leveltoload);
            
            thePlayer.startPoint = exitPoint;
        }
    } 
}
