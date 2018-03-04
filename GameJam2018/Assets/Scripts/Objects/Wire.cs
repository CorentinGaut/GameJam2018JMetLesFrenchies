using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : BaseObject {


    // Use this for initialization
    void Start()
    {
        baseHeight = gameObject.transform.position.y;

        maxHP = 50;
        isRepared = true;
        repareCooldown = 1.0f;
        itemsWellPlacedandRepared.Add(false);

        itemId = id;
        id++;
    }

    // Update is called once per frame
    protected override void Update()
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


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "CableEmplacement" && transform.parent == null)
        {

            isWellPlaced = true;
            if (isRepared && listCreated)
            {
                itemsWellPlacedandRepared[itemId] = true;
                CheckItemList();
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "CableEmplacement")
        {

            isWellPlaced = false;
            itemsWellPlacedandRepared[itemId] = false;

        }
    }
}
