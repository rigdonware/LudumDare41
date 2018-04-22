using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardTurret : Turret {
	public int cost = 10;

	public override void Start () {
		base.Start();
		range = 20f;
		shootCooldown = 1;
	}

	public override void Update () {
		base.Update();
	}
}
