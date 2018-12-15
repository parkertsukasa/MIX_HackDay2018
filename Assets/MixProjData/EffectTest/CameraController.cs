using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {
    void Start () {
       // this.transform.DORotate(
       //    new Vector3(0.0f, 0.0f, 180.0f),
       //    0.6f
       //);
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.D)) {
            //this.transform.DOLocalRotate(new Vector3(0.0f, 0.0f,this.transform.localEulerAngles.z+180.0f), 0.15f).SetEase(Ease.InOutCirc);
            
        }
    }
}
