using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : BaseObject {


    // Use this for initialization
    void Start ()
    {
        baseHeight = gameObject.transform.position.y;

        HP = 250;
        maxHP = 250;
        isRepared = true;
        repareCooldown = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {

        if (repareCooldown > 0)
            repareCooldown -= Time.deltaTime;
	}

    public override void Destroy()
    {
        base.Destroy();
    }

    public override void Repare()
    {
        base.Repare();
    }


    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "CPUEmplacement" && transform.parent == null)
        {

            if (HP == maxHP)
            {
            }
            else
            {
            }

        }
    }
}
