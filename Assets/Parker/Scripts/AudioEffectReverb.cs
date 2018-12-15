using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioEffectReverb : MonoBehaviour 
{

	private Slider slider;
	private AudioReverbFilter reverb;

  // Use this for initialization
  void Start ()
	{ 
		slider = GetComponent<Slider>();
		reverb = GameObject.FindWithTag("MainCamera").GetComponent<AudioReverbFilter>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		reverb.dryLevel = slider.value;
	}
}
