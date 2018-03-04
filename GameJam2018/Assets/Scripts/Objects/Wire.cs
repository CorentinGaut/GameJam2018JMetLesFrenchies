using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : BaseObject {


    // Use this for initialization
    void Start()
    {
        baseHeight = gameObject.transform.position.y;

        HP = 50;
        maxHP = 50;
        isRepared = true;
        repareCooldown = 1.0f;
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
        if (collision.tag == "CableEmplacement" && transform.parent == null)
        {
            Debug.Log("Cable est au bon endroit");

            if (HP == maxHP)
            {
                Debug.Log("Cable est au bon endroit, objet réparé");
            }
            else
            {
                Debug.Log("Reparer l'objet");
            }

        }
    }
}
