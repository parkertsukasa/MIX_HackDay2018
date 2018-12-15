using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGenerator : MonoBehaviour {

    public GameObject Prism;
    public int num = 50;
    private GameObject[] Prisms;
    private Vector3[] vel;
	void Start (){
        Prisms = new GameObject[num];
        vel = new Vector3[num];
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.S)) {
            for (int i = 0; i < num; i++) {
                Prisms[i] = Instantiate(Prism);
                Prisms[i].transform.position = Random.insideUnitSphere * 1.0f;
                Destroy(Prisms[i], 1.0f);
            }
        }
	}
}
