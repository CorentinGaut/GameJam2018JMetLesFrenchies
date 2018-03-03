using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nvidiotActions : MonoBehaviour {

    // Freeze tous "Buttons" quand nvidiot est actif
    // Instancie les blueblocks un par un suivant temps

    public GameObject buttons;

	// Use this for initialization
	void Start () {
        buttons = transform.Find("Buttons").gameObject;
        Debug.Log("I AM NVIDIOT !!!");
        Debug.Log(buttons);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
