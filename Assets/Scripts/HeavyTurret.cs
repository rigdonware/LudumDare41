using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyTurret : Turret {
	public int cost = 30;

	public override void Start () {
		base.Start();
		range = 20f;
		shootCooldown = 1;
	}

	public override void Update () {
		base.Update();
	}
}
