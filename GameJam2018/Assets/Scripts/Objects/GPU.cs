using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPU : BaseObject {

    // Use this for initialization
    void Start()
    {
        baseHeight = gameObject.transform.position.y;
        maxHP = 350;
        isRepared = true;
        repareCooldown = 1.0f;
    }

    // Update is called once per frame
    protected override void  Update()
    {
        base.Update();

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
        if (collision.tag == "GPUEmplacement" && transform.parent == null)
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
