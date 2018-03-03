using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WindowsButton : MonoBehaviour {

    private Button[] listButtons;
    private UnityAction[] tabFonctions = { functionButtonDemarrer.Invoke(), buttonIcon };

	// Use this for initialization
	void Start () {
        // Array des button children

        listButtons = this.GetComponentsInChildren<Button>();
        
        for (int i = 0; i < listButtons.Length; i++)
        {
            listButtons[i].onClick.AddListener(functionButtonDemarrer);
            // listButton[i].onclick.addeventlistenner(tabFunctions[i]);
            // Soit on code le tabfunction brut ou on récupere par script par les names
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void functionButtonDemarrer()
    {
        Debug.Log("Test bouton demarrer réussi !");
    }

    void buttonIcon()
    {
        Debug.Log("Test bouton icon reussi !");
    }

}
