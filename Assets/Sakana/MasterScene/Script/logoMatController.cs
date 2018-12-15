using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logoMatController : MonoBehaviour {

    //public Material material;
    public GameObject audio;
    AudioSpectrum _as;
    void Start () {
        _as = audio.GetComponent<AudioSpectrum>();
		
	}
	
	void Update () {
        this.GetComponent<MeshRenderer>().material.color = new Color(_as.MeanLevels[0] * 3.0f, 1.0f, 1.0f);
        
	}
}
