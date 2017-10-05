using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {
    private Slider slider;
    private VolumeManager vm;


	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        vm = FindObjectOfType<VolumeManager>();
	}
	
	// Update is called once per frame
	void Update () {
        vm.currentVolumeLevel = slider.value;
	}
}
