using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDataManager : MonoBehaviour 
{

	// --- データとして置いておく配列 ---
	public AudioClip[] voiceSounds;

	// --- Button側に開示する参照用の配列 ---
	public AudioClip[] selectedSounds;

	private int nowSelected = 0;

	public int nowPressed;

	// Use this for initialization
	void Start () 
	{
		nowPressed = 12;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(nowSelected == 0)
			selectedSounds = voiceSounds;

		
	}
}
