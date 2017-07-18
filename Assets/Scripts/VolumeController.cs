using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour {

    private AudioSource theAudio;
    private float audioLevel;
    public float defaultAudio;
    private VolumeManager vm;
    private static bool volExists;

	// Use this for initialization
	void Start () {
        theAudio = GetComponent<AudioSource>();
        vm = FindObjectOfType<VolumeManager>();
        /*if (!volExists)
        {
            volExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/
    }
	
	// Update is called once per frame
	void Update () {
		if(gameObject.name == "DamageBurst")
        {
            gameObject.GetComponent<AudioSource>().volume = vm.currentVolumeLevel;
        }
	}
    public void setAudioLevel(float volume)
    {
        if(theAudio == null)
        {
            theAudio = GetComponent<AudioSource>();
        }
        audioLevel = defaultAudio * volume;
        theAudio.volume = audioLevel;
    }
}
