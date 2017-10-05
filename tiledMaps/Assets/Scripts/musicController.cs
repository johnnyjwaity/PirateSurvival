using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicController : MonoBehaviour {

    private static bool mcExists;

    public AudioSource[] tracks;

    public int currentTrack;

    public bool musicCanPlay;

	// Use this for initialization
	void Start () {
        if (!mcExists)
        {
            mcExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (musicCanPlay)
        {
            if (!tracks[currentTrack].isPlaying)
            {
                tracks[currentTrack].Play();
            }
        }
        else
        {
            tracks[currentTrack].Stop();
        }
	}
    public void switchTrack(int newTrack)
    {
        tracks[currentTrack].Stop();
        currentTrack = newTrack;
        tracks[currentTrack].Play();
    }
}
