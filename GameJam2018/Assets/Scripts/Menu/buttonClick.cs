using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonClick : MonoBehaviour {

    private Button[] listButtons;
    private UnityAction[] tabFonctions;
    private GameObject dlcWindows , tutoWindow;
    private bool boolWindows , boolTutoWindows;



    // Use this for initialization
    void Start () {
        UnityAction[] tabFonctions = {  functionButtonUser1 , functionButtonUser2 , functionButtonClose , functionButtonTuto, // fonction des premiers boutons
                                        functionButtonFermer , // fonction de dlcWindows
                                        functionButtonFermer }; // fonction de TutoLayout

        listButtons = this.GetComponentsInChildren<Button>();
        for (int i = 0; i < listButtons.Length; i++)
        {
            listButtons[i].onClick.AddListener(tabFonctions[i]);
        }
        Debug.Log(listButtons.Length);

        dlcWindows = this.transform.Find("dlcWindows").gameObject;
        boolWindows = false;
        dlcWindows.SetActive(boolWindows);

        tutoWindow = this.transform.Find("TutoLayout").gameObject;
        boolTutoWindows = false;
        tutoWindow.SetActive(boolTutoWindows);
    }
	
	// Update is called once per frame
	void Update () {

    }

    void functionButtonUser1()
    {
        Debug.Log("Test bouton User1 réussi !");
        //SceneManager.LoadScene("testWindows");
        SceneManager.LoadScene("New Scene");
    }

    void functionButtonUser2()
    {
        if (!boolWindows)
        {
            boolWindows = true;
            dlcWindows.SetActive(boolWindows);
            boolWindows = !boolWindows;
        }
    }
    
    void functionButtonClose()
    {
        Debug.Log("Test bouton FERMER réussi !");
        Application.Quit();
    }

    void functionButtonTuto()
    {
        if (!boolWindows)
        {
            boolTutoWindows = true;
            tutoWindow.SetActive(boolTutoWindows);
            boolWindows = !boolTutoWindows;
        }
    }
    void functionButtonFermer()
    {
        Debug.Log("Bouton fermer ne doit rien renvoyer !");
    }

}
