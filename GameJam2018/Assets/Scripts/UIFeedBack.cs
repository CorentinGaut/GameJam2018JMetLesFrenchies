using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIFeedBack : MonoBehaviour {

    public GameObject Composant;

    int composantHP;
    int composantHPMax;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        composantHP = Composant.GetComponent<BaseObject>().HP;
        composantHPMax = Composant.GetComponent<BaseObject>().maxHP;

        if (composantHP/composantHPMax != 1)
        {
            this.GetComponent<Image>().color = new Color(0.9f, 0.0f, 0.0f, 0.8f);
        }
        else
        {
            this.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
        }
        
	}
}
