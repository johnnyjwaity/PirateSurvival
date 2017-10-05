using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour {
    public VolumeController[] vcs;
    private Slider slider;

    public float currentVolumeLevel;
    public float MaxVolumeLevel = 1.0f;
    private static bool vmExists;
	// Use this for initialization
	void Start () {
        vcs = FindObjectsOfType<VolumeController>();

        /*if (!vmExists)
        {
            vmExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/

        if (currentVolumeLevel > MaxVolumeLevel)
        {
            currentVolumeLevel = MaxVolumeLevel;
        }

        for(int i =0; i<vcs.Length; i++)
        {
            vcs[i].setAudioLevel(currentVolumeLevel);
        }
        //slider = FindObjectOfType<volumeSlider>().GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {

        /*if(FindObjectOfType<volumeSlider>().GetComponent<Slider>() != null)
        {
            slider = FindObjectOfType<volumeSlider>().GetComponent<Slider>();
        }

        if (slider != null)
        {
            currentVolumeLevel = slider.value;
        }*/
        
        for (int i = 0; i < vcs.Length; i++)
        {
            vcs[i].setAudioLevel(currentVolumeLevel);
        }
    }
}
