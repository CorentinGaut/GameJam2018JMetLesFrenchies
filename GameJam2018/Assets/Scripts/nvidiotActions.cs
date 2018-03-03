using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nvidiotActions : MonoBehaviour {
    
    public GameObject buttons;
    public GameObject blueBlock;
    private Vector3 coordBlue;
    private int compt;
    public float timeDelay;
    private GameObject[] tabBlockClone;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Dans Start");
        buttons.SetActive(false);
        Invoke("updateBlueBar", 1);
        coordBlue = new Vector3(0, 0, 0);
        compt = 0;
        tabBlockClone = new GameObject[25];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void updateBlueBar()
    {
        Debug.Log("Dans UpdateBluBar");
        for (int i = 0; i < 25; i++)
        {
            var range = Random.Range(1f, timeDelay);
            Invoke("instentiateBlueBar", range);
        }
    }

    void instentiateBlueBar()
    {
        Debug.Log("Dans instentiateBlueBar");
        var clone = Instantiate(blueBlock, new Vector3(), new Quaternion(), this.transform.parent);
        coordBlue = clone.transform.position;
        coordBlue.x += 10 * compt;
        clone.transform.position = coordBlue;
        tabBlockClone[compt] = clone;
        compt++;
        Debug.Log(compt);
        if (compt == 25)
        {
            endOfNvidio();
        }
    }

    void endOfNvidio()
    {
        compt = 0;
        for (int i = 0; i < tabBlockClone.Length; i++)
        {
            Destroy(tabBlockClone[i]);
        }
        this.gameObject.SetActive(false);
        buttons.SetActive(true);
    }
}
