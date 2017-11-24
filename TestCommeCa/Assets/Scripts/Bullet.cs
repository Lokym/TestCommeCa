using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile {

    public int speedValue;

    protected override void Start()
    {
        base.Start();
        speed = speedValue;
        Dmg = 10;
    }

   
}
