using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WindowsButton : MonoBehaviour {

    private Button[] listButtons;
    private UnityAction[] tabFonctions;
    private GameObject colomneDemarrer;
    private bool boolDemarrer;

    // Use this for initialization
    void Start () {
        UnityAction[] tabFonctions = { functionButtonDemarrer, functionButtonIcon, functionButtonInternet, functionButtonDiablo };

        colomneDemarrer = this.transform.Find("colomneDemarrer").gameObject;
        boolDemarrer = false;
        colomneDemarrer.SetActive(boolDemarrer);

        listButtons = this.GetComponentsInChildren<Button>();

        Debug.Log("avant l'init des boutons");
        Debug.Log(listButtons.Length);
        for (int i = 0; i < listButtons.Length; i++)
        {
            listButtons[i].onClick.AddListener(tabFonctions[i]);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void functionButtonDemarrer()
    {
        Debug.Log("Test bouton demarrer réussi !");
        if (boolDemarrer)
        {
            boolDemarrer = false;
            colomneDemarrer.SetActive(boolDemarrer);
        }
        else if (!boolDemarrer)
        {
            boolDemarrer = true;
            colomneDemarrer.SetActive(boolDemarrer);
        }
    }

    void functionButtonIcon()
    {
        Debug.Log("Test bouton icon reussi !");
    }

    void functionButtonInternet()
    {
        Debug.Log("Test bouton internet réussi !");
    }

    void functionButtonDiablo()
    {
        Debug.Log("Test bouton diablo reussi !");
    }
}
