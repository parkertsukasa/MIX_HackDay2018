using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDataManager : MonoBehaviour 
{

	// --- データとして置いておく配列 ---
	public AudioClip[] youseiVoice;
	public AudioClip[] sakuVoice;

	// --- Button側に開示する参照用の配列 ---
	public AudioClip[] selectedSounds;

	// --- AudioClipを全管理 ---
	public GameObject[] buttons;

	[SerializeField]
	private bool nowSelected;

	public int nowPressed;

	// Use this for initialization
	void Start () 
	{
		nowPressed = 12;

		nowSelected = true;
		selectedSounds = youseiVoice;

		for (int i = 0; i < 12; i++)
		{
			buttons[i].GetComponent<SoundButton>().clip = selectedSounds[i];
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 accel = Input.acceleration;
		float  length = Vector3.Magnitude(accel);

		if (length > 2.0f)
			ChangeSounds();
		
	}

	void ChangeSounds()
	{
		nowSelected = !nowSelected;

		if (nowSelected)
			selectedSounds = youseiVoice;
		else
			selectedSounds = sakuVoice;
			
		for (int i = 0; i < 12; i++)
		{
			buttons[i].GetComponent<SoundButton>().clip = selectedSounds[i];
		}

	}

}
