﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestNvidia : MonoBehaviour {

    public GameObject nvidio;
    private Button butTest;

	// Use this for initialization
	void Start () {
        butTest = this.GetComponent<Button>();
        butTest.onClick.AddListener(freezeScreen);
        Debug.Log(butTest);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void freezeScreen()
    {
        Debug.Log("I AM IN FREEZESCREEN");
        nvidio.SetActive(true);
    }
}
