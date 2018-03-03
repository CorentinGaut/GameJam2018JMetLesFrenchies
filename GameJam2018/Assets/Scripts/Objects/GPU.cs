﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPU : BaseObject {

    // Use this for initialization
    void Start()
    {
        HP = 350;
        maxHP = 350;
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
}