using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMorton : MonoBehaviour {
    
    private int compt;
    private UnityEngine.UI.Image[] tabBlockClone;
    public float timeDelay;

    // Use this for initialization
    void Start () {
        compt = 0;
        tabBlockClone = GameObject.Find("LoadingBarreMorton").GetComponentsInChildren<UnityEngine.UI.Image>();
        for (var i = 0; i < tabBlockClone.Length; i++)
        {
            tabBlockClone[i].gameObject.SetActive(false);
        }
        Invoke("updateBlueBar", 1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void updateBlueBar()
    {
        Debug.Log("Dans UpdateBluBar");
        for (int i = 0; i < 38; i++)
        {
            var range = Random.Range(1f, timeDelay);
            Invoke("instentiateBlueBar", timeDelay*i);// 3.15f second
        }
    }

    void instentiateBlueBar()
    {
        Debug.Log(compt);
        tabBlockClone[compt].gameObject.SetActive(true);
        compt++;
        if (compt == tabBlockClone.Length)
        {
            // Fin du jeu Changement de scene suivant les scores
            Debug.Log("FIN DU JEU");
        }
    }
}
