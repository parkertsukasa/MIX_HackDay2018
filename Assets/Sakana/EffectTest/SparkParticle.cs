using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkParticle : MonoBehaviour {
    private ParticleSystem _ps;

	void Start () {
	    	
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q)) {
            _ps = this.GetComponent<ParticleSystem>();
            _ps.Play();
        }
	}
}
