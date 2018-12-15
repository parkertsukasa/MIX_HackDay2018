using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectMenuManager : MonoBehaviour 
{
	[SerializeField]
	private Canvas effectCanvas;
	[SerializeField]
	private Animator menuBackAnimator;
	[SerializeField]
	private Canvas soundCanvas;

	// Use this for initialization
	void Start () 
	{
		effectCanvas.enabled = false;
		soundCanvas.enabled = true;
		menuBackAnimator.SetBool("MenuEnabled", false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void EffectMenuButton()
	{
		if (effectCanvas.enabled == true) // すでにMenuが出ている時
		{
			menuBackAnimator.SetBool("MenuEnabled", false);
			Invoke("EffectMenuOut", 1.0f);
		}
		else // Menuが出ていない時
		{
			effectCanvas.enabled = true;
			menuBackAnimator.SetBool("MenuEnabled", true);
		}
	}

	void EffectMenuOut()
	{
		effectCanvas.enabled = false;// !effectCanvas.enabled;
	}

}
