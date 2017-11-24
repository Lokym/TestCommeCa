﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Rifleman : PLayerController {

    public GameObject SpawnGO;
    public GameObject bullet;



    public override void Effect()
    {
        if (Menu.isMulti)
        {
            CmdInstatiate();
        }

        else if (Menu.isSolo)
        {
            Instantiate(bullet, SpawnGO.transform.position, transform.rotation);
        }
    }

    [Command]
    void CmdInstatiate()
    {
        GameObject tmp = Instantiate(bullet, SpawnGO.transform.position, transform.rotation);
        NetworkServer.Spawn(tmp);
    }

    public override void Stats(int ChangeSpeed, float ChangeLife)
    {
        base.Stats(7, 150);
    }

    protected override void Shoot(float FireRate)
    {
        base.Shoot(15f);
    }
}