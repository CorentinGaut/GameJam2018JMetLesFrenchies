using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : BaseObject {


    // Use this for initialization
    void Start () {
        HP = 100;
        maxHP = 200;
        isRepared = false;
        repareCooldown = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetButton("Jump"))
        //    Repare();
        //if (Input.GetButton("Fire1"))
        //    Destroy();
        if (repareCooldown > 0)
            repareCooldown -= Time.deltaTime;
	}

    protected override void Destroy()
    {
        base.Destroy();
    }

    protected override void Repare()
    {
        base.Repare();
    }
}
