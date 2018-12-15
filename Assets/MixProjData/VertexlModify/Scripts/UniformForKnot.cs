using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniformForKnot : MonoBehaviour
{
	public Material mat;
	public GameObject osc;
	//private OscManager om;
	private float vol;
	private float bufferVol;
	void Start () {
		//om = osc.GetComponent<OscManager>();
		bufferVol = 0.0f;
	}
	
	void Update () {
		////mat.SetFloat("_Vol", om.Vol*10.0f);
		mat.SetFloat("_BufferVol", bufferVol*10.0f);

		//bufferVol = om.Vol;
	}
}
