using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closeWindows : MonoBehaviour {

    public Button close;

    // Use this for initialization
    void Start () {
        close.onClick.AddListener(functionFermer);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void functionFermer()
    {
        this.gameObject.SetActive(false);
    }
}
