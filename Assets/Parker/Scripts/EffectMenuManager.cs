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

	[SerializeField]
	private Image menuButton;

	[SerializeField]
	private Sprite cross;

	[SerializeField]
	private Sprite gear;

	[SerializeField]
	private GameObject uiAll;

	// Use this for initialization
	void Start () 
	{
		effectCanvas.enabled = false;
		soundCanvas.enabled = true;
		menuBackAnimator.SetBool("MenuEnabled", false);
		uiAll.SetActive(false);
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
			UIOut();
			Invoke("EffectMenuOut", 0.35f);
		}
		else // Menuが出ていない時
		{
			effectCanvas.enabled = true;
			menuBackAnimator.SetBool("MenuEnabled", true);
			menuButton.sprite = cross;
			Invoke("UIIn", 0.35f);
		}
	}

	void UIIn()
	{
		uiAll.SetActive(true);
	}

	void UIOut()
	{
		uiAll.SetActive(false);
	}

	void EffectMenuOut()
	{
		effectCanvas.enabled = false;// !effectCanvas.enabled;
		menuButton.sprite = gear;
	}

}
