using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTurret : Turret {
	public int cost = 20;

	public override void Start () {
		base.Start();
		range = 20f;
		shootCooldown = 1.5f;
		bulletSpeed = 40;
		damage = 15;
	}

	public override void Update () {
		base.Update();
	}
}
