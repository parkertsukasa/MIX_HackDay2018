using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioEffectLowPass : MonoBehaviour {

	private Slider slider;
	private AudioLowPassFilter lowPass;

  // Use this for initialization
  void Start ()
	{ 

		slider = GetComponent<Slider>();

		lowPass = GameObject.FindWithTag("MainCamera").GetComponent<AudioLowPassFilter>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		lowPass.cutoffFrequency = slider.value;
	}
}
