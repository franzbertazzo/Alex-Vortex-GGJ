﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSensor : MonoBehaviour {


    public GameObject Text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Text.SetActive(true);
    }
}