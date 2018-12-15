using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioEffectHighPass : MonoBehaviour {

	private Slider slider;
	private AudioHighPassFilter chorusFilter;

  // Use this for initialization
  void Start ()
	{ 

		slider = GetComponent<Slider>();

		chorusFilter = GameObject.FindWithTag("MainCamera").GetComponent<AudioHighPassFilter>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		chorusFilter.cutoffFrequency = slider.value;
	}
}
