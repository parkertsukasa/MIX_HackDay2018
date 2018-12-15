using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectMenuManager : MonoBehaviour 
{
	[SerializeField]
	private Canvas effectCanvas;
	[SerializeField]
	private Canvas soundCanvas;

	// Use this for initialization
	void Start () 
	{
		effectCanvas.enabled = false;
		soundCanvas.enabled = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void EffectMenuButton()
	{
		effectCanvas.enabled = !effectCanvas.enabled;
		soundCanvas.enabled = !soundCanvas.enabled;
	}

}
