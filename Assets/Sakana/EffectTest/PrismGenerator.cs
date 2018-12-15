﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismGenerator : MonoBehaviour {

    public GameObject Prism;
    public int num = 50;
    private GameObject[] Prisms;
    private Vector3[] vel;

    private SoundDataManager dataManager;
    
	void Start (){
        Prisms = new GameObject[num];
        vel = new Vector3[num];        
        dataManager = GameObject.Find("Speaker").GetComponent<SoundDataManager>();


	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.A) || dataManager.nowPressed == 9) {
            for (int i = 0; i < num; i++) {
                Prisms[i] = Instantiate(Prism);
                Prisms[i].transform.position = Random.insideUnitSphere * 1.0f;
                Destroy(Prisms[i], 1.0f);
            }
        }
	}
}