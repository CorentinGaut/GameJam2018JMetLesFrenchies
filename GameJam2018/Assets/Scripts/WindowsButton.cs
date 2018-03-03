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
    private GameObject posteTravail;
    private bool boolPosteTravail;
    private GameObject diablo;
    private bool boolDiablo;

    // Use this for initialization
    void Start () {
        UnityAction[] tabFonctions = { functionButtonDemarrer, functionButtonPosteTravail, functionButtonInternet, functionButtonDiablo, //fonction du bureau
                                        functionButtonPosteTravail, functionButtonInternet, functionButtonDiablo, functionButtonInvCommande, functionButtonTousProgs, // fonction de demarrer
                                        functionFermer, functionButtonChance, functionButtonRecherche, // fonction de google1
                                        functionFermer, functionPrecedent,// fonction de google2
                                        functionFermer, // fonction de poste travail
                                        functionFermer}; // fonction de diablo

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

        // Poste de Travail Initialisation
        posteTravail = this.transform.Find("PostTravail").gameObject;
        boolPosteTravail = false;
        posteTravail.SetActive(boolPosteTravail);

        // Diablo Initialisation
        diablo = this.transform.Find("Diablo").gameObject;
        boolDiablo = false;
        diablo.SetActive(boolDiablo);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void functionButtonDemarrer()
    {
        Debug.Log("Test bouton demarrer réussi !");
        if (boolDemarrer) // Cacher demarrer
        {
            boolDemarrer = false;
            colomneDemarrer.SetActive(boolDemarrer);
        }
        else if (!boolDemarrer) // Afficher Demarrer
        {
            boolDemarrer = true;
            colomneDemarrer.SetActive(boolDemarrer);
        }
    }

    void functionButtonPosteTravail()
    {
        Debug.Log("Test bouton Poste de Travail reussi !");
        if (!boolPosteTravail)
        {
            boolPosteTravail = true;
            posteTravail.SetActive(boolPosteTravail);
            boolPosteTravail = false;
        }
        if (boolDemarrer) // Cacher demarrer
        {
            boolDemarrer = false;
            colomneDemarrer.SetActive(boolDemarrer);
        }
    }

    void functionButtonInternet()
    {
        Debug.Log("Test bouton internet réussi !");
        if (!boolGoogle)
        {
            boolGoogle = true;
            google.SetActive(boolGoogle);
            boolGoogle = false;
        }
        if (boolDemarrer) // Cacher demarrer
        {
            boolDemarrer = false;
            colomneDemarrer.SetActive(boolDemarrer);
        }
    }

    void functionFermer()
    {
        Debug.Log("Ne doit rien faire (Fermer)");
    }

    void functionPrecedent()
    {
        Debug.Log("Ne doit rien faire (Retour)");
    }

    void functionButtonChance()
    {
        if (!boolGoogle2) // Ouvre nouvelle page google2
        {
            boolGoogle2 = true;
            google2.SetActive(boolGoogle2);
            boolGoogle2 = false;
            if (boolGoogle) // Ferme l'ancienne page (google1)
            {
                boolGoogle = false;
                google.SetActive(boolGoogle);
                boolGoogle = true;
            }
        }
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
        if (!boolDiablo)
        {
            boolDiablo = true;
            diablo.SetActive(boolDiablo);
            boolDiablo = false;
        }
        if (boolDemarrer) // Cacher demarrer
        {
            boolDemarrer = false;
            colomneDemarrer.SetActive(boolDemarrer);
        }
    }

    void functionButtonInvCommande()
    {
        Debug.Log("Test bouton Invite de commande reussi !");
        if (boolDemarrer) // Cacher demarrer
        {
            boolDemarrer = false;
            colomneDemarrer.SetActive(boolDemarrer);
        }
    }

    void functionButtonTousProgs()
    {
        Debug.Log("Test bouton Tous les progs reussi !");
    }
}
