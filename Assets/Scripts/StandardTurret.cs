using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardTurret : Turret {
	public int cost = 10;

	public override void Start () {
		base.Start();
		range = 15f;
		shootCooldown = .5f;
		bulletSpeed = 20;
		damage = 10;
	}

	public override void Update () {
		base.Update();
	}
}
