using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseCharacter {

	// Use this for initialization
	public override void Start () {
		base.Start();
		tower = GameObject.Find("PlayerTower");
		attackPower = 10;
		attackRadius = 5;
		attackCooldown = 2;
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
	}
}

