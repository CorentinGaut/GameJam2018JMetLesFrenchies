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
    public GameObject[] listPopUps;
    private int comptPopUp;
    public float timePopUp;
    private GameObject google;
    private bool boolGoogle;
    private GameObject google2;
    private bool boolGoogle2;

    // Use this for initialization
    void Start () {
        UnityAction[] tabFonctions = { functionButtonDemarrer, functionButtonPosteTravail, functionButtonInternet, functionButtonDiablo, //fonction du bureau
                                        functionButtonPosteTravail, functionButtonInternet, functionButtonDiablo, functionButtonInvCommande, functionButtonTousProgs, // fonction de demarrer
                                        functionFermer, functionButtonChance, functionButtonRecherche, // fonction de google1
                                        functionFermer}; // fonction de google2

        listButtons = this.GetComponentsInChildren<Button>();
        for (int i = 0; i < listButtons.Length; i++)
        {
            listButtons[i].onClick.AddListener(tabFonctions[i]);
        }
        Debug.Log(listButtons.Length);

        // Colomne Démarrer Initialisation
        colomneDemarrer = this.transform.Find("colomneDemarrer").gameObject;
        boolDemarrer = false;
        colomneDemarrer.SetActive(boolDemarrer);

        // Google Initialisation
        google = this.transform.Find("Google").gameObject;
        boolGoogle = false;
        google.SetActive(boolGoogle);
        google2 = this.transform.Find("ChanceResult").gameObject;
        boolGoogle2 = false;
        google2.SetActive(boolGoogle2);
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
        if (!boolDemarrer)
        {
            boolDemarrer = true;
            google.SetActive(boolDemarrer);
        }
        
    }

    void functionFermer()
    {
        boolDemarrer = false;
        google.SetActive(boolGoogle);
    }

    void functionButtonChance()
    {
        boolGoogle2 = true;
        google2.SetActive(boolGoogle2);
    }

    void functionButtonRecherche()
    {
        comptPopUp = 0;
        Invoke("pupUps", 0);
        Invoke("pupUps", timePopUp);
        Invoke("pupUps", timePopUp * 2);
        comptPopUp = 0;
    }

    void pupUps()
    {
        Instantiate(listPopUps[comptPopUp], this.transform);
        comptPopUp++;
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
