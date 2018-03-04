using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : BaseObject {


    // Use this for initialization
    void Start()
    {
        HP = 1000;
        maxHP = 1000;
        isRepared = true;
        repareCooldown = 1.0f;
        baseHeight = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

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
        if (collision.tag == "VisEmplacement" && transform.parent == null)
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
