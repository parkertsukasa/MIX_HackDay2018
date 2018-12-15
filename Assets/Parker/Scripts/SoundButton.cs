using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour 
{
  public int soundID;

	private AudioSource audioSource;

	public AudioClip clip;

	private SoundDataManager dataManager;


	// Use this for initialization
	void Start () 
	{
		audioSource = GetComponent<AudioSource>();
		dataManager = GameObject.Find("Speaker").GetComponent<SoundDataManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void ButtonPressed()
	{
		audioSource.PlayOneShot(clip);
		dataManager.nowPressed = soundID;
	}

	public void ButtonRelease()
	{
		audioSource.Stop();
		dataManager.nowPressed = 12;
	}

}
