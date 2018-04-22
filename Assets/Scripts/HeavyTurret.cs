using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyTurret : Turret {
	public int cost = 30;

	public override void Start () {
		base.Start();
		range = 10f;
		shootCooldown = 1;
		bulletSpeed = 20;
		damage = 20;
	}

	public override void Update () {
		base.Update();
	}
}
