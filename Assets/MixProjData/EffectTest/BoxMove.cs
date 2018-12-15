using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour {
    private Vector3 _vel;
	void Start () {
        _vel = (this.transform.position - Vector3.zero).normalized;
        this.transform.LookAt(Vector3.zero);
	}
	
	void Update () {
        this.transform.position += _vel * 0.5f;
	}
}
