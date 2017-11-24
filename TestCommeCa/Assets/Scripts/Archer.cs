using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Archer : PLayerController {

   
    public GameObject fleche;
    public GameObject SpawnGO;
    
   

    public override void Effect()
    {
        if (Menu.isMulti)
        {
            CmdInstatiate();
        }

        else if (Menu.isSolo)
        {
            Instantiate(fleche, SpawnGO.transform.position, transform.rotation);
        }

    }

    [Command]
    void CmdInstatiate()
    {
        GameObject tmp = Instantiate(fleche, SpawnGO.transform.position, transform.rotation);
        NetworkServer.Spawn(tmp);
    }

    public override void Stats(int ChangeSpeed, float ChangeLife)
    {
        base.Stats(7, 100);
    }

    protected override void Shoot(float FireRate)
    {
        base.Shoot(5f);
    }
}
