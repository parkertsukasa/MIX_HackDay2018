using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
	public GameObject obj;
	void Start () {
		
	}
	
	
	void Update () {
		var targetRot = Quaternion.LookRotation (obj.transform.position - gameObject.transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime);

		Debug.Log(Time.realtimeSinceStartup);
	}


	
}
