using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleche : Projectile {

    public int speedValue;

    protected override void Start()
    {
        base.Start();
        speed = speedValue;
        Dmg = 30;
    }

   
}
