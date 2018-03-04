using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : BaseObject {


    // Use this for initialization
    void Start()
    {
        Destroy();
        baseHeight = gameObject.transform.position.y;
        maxHP = 200;
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
        if (collision.tag == "FanEmplacement" && transform.parent == null)
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
        if (collision.tag == "FanEmplacement")
        {

            isWellPlaced = false;
            itemsWellPlacedandRepared[itemId] = false;

        }
    }
}
