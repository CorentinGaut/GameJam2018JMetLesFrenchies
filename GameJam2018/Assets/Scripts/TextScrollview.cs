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
		// Debug.Log(compteur);
		// var tmp=this.GetComponent<RectTransform>() as RectTransform;
		// var tmpPos=tmp.anchoredPosition;
		// tmpPos.x=-954.7f;
		// tmpPos.y=tmpPos.y-50f*compteur;
		// compteur++;
		// tmp.position=tmpPos;
		// Debug.Log(tmp.position);
		// var clone = Instantiate(prefab,tmp);
		// var texte = clone.text;
		// texte+=txt+"_";
		// clone.text=texte;
		// var tmp3=this.GetComponent<RectTransform>().anchoredPosition;
		// tmp3.x=0;
	}
}
