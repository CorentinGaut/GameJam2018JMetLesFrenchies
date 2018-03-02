using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObject : MonoBehaviour {

    public int HP;
    public bool isRepared;
    public int maxHP;
    public float repareCooldown;
    public BoxCollider repareBox;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected virtual void Repare()
    {
        HP = 0;
        isRepared = false;
    }

    protected virtual void Destroy()
    {
        if (repareCooldown <= 0 && !isRepared)
        {
            HP += 10;
            repareCooldown = 1;
            if (HP == maxHP)
                isRepared = true;
        }
    }
}
