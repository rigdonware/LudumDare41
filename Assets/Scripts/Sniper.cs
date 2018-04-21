using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : BaseCharacter {

	// Use this for initialization
	public override void Start () {
		base.Start();
		roundUp = GameObject.Find("SniperRoundup");
		tower = GameObject.Find("EnemyTower");
		attackRadius = 10.0f;
		attackPower = 25;
		attackCooldown = 3;
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
		if(!targetEnemy)
		{
			GetComponent<Animator>().Play("Walking");
		}
	}

	public override void AttackEnemy()
	{
		base.AttackEnemy();
		GetComponent<Animator>().Play("Sniping");
	}
}
