using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nvidiotActions : MonoBehaviour {

    // Freeze tous "Buttons" quand nvidiot est actif
    // Instancie les blueblocks un par un suivant temps

    public GameObject buttons;
    public GameObject blueBlock;
    private Vector2 coordBlue;

    // Use this for initialization
    void Start () {
        Debug.Log("I AM NVIDIOT !!!");
        Debug.Log(buttons);
        buttons.SetActive(false);
        Invoke("updateBlueBar", 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // coordonnées de départ (-215, -122) il faut faire +18 en x
    void updateBlueBar()
    {
        Instantiate(blueBlock, coordBlue, this.transform);
    }
}
