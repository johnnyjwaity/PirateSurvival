using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour {
    public tracker room;
    public GameObject redirect;
    public bool pathFinish;
	public bool notInRoom;
    private GameObject player;
	// Use this for initialization
	void Start () {
        if (!pathFinish)
        {
            room = room.GetComponent<tracker>();
        }
        player = FindObjectOfType<PlayerController>().gameObject;
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
		if(collision.tag == "Enemy" && collision.GetComponent<slimeController>() == null  && !pathFinish && collision.GetComponent<FollowAI>())
        {
			if (!notInRoom) {
				if (room.playerHere) {
					collision.GetComponent<FollowAI> ().target = redirect;
				} else {
					collision.GetComponent<FollowAI> ().target = redirect;
				}
			} else {
				if (!room.playerHere) {
					collision.GetComponent<FollowAI> ().target = redirect;
				} else {
					collision.GetComponent<FollowAI> ().target = null;
				}
			}
			
            
        }
		if (pathFinish && collision.tag == "Enemy" && collision.GetComponent<slimeController>() == null && collision.GetComponent<FollowAI>())
        {
            collision.GetComponent<FollowAI>().target = null;
        }
    }
}
