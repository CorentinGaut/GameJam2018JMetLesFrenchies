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
        UnityAction[] tabFonctions = { functionButtonDemarrer, functionButtonPosteTravail, functionButtonInternet, functionButtonDiablo, //fonction du bureau
                                        functionButtonPosteTravail, functionButtonInternet, functionButtonDiablo, functionButtonInvCommande, functionButtonTousProgs}; // fonction de demarrer

        listButtons = this.GetComponentsInChildren<Button>();
        for (int i = 0; i < listButtons.Length; i++)
        {
            listButtons[i].onClick.AddListener(tabFonctions[i]);
        }
        Debug.Log(listButtons.Length);

        colomneDemarrer = this.transform.Find("colomneDemarrer").gameObject;
        boolDemarrer = false;
        colomneDemarrer.SetActive(boolDemarrer);
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

    void functionButtonPosteTravail()
    {
        Debug.Log("Test bouton Poste de Travail reussi !");
    }

    void functionButtonInternet()
    {
        Debug.Log("Test bouton internet réussi !");
    }

    void functionButtonDiablo()
    {
        Debug.Log("Test bouton diablo reussi !");
    }

    void functionButtonInvCommande()
    {
        Debug.Log("Test bouton Invite de commande reussi !");
    }

    void functionButtonTousProgs()
    {
        Debug.Log("Test bouton Tous les progs reussi !");
    }
}
