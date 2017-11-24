using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Projectile {

    public int speedValue;

    protected override void Start()
    {
        base.Start();
        speed = speedValue;
        Dmg = 40;
        ExploRadius = 3;
       
    }
}
