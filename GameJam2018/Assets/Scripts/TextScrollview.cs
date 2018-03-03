using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScrollview : MonoBehaviour {

	// Use this for initialization

	public UnityEngine.UI.Text prefab;
	private int compteur;
	void Start () {
		compteur=0;
		AddText("test");
		AddText("test2");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Creer un objet text avec le text txt
	void AddText(string txt){
		//var clone = Instantiate(prefab,this.transform.position-this.transform.up,this.transform.rotation);
		//var tmp = this.transform;
		var tmp=prefab.rectTransform;
		var tmpPos=tmp.position;
		tmpPos.y-=14*compteur;
		Debug.Log(tmpPos.y);
		compteur++;
		var clone = Instantiate(prefab,tmp);
		var texte = clone.text;
		texte+=txt+"_";
		clone.text=texte;
	}
}
