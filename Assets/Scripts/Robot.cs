using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : BaseCharacter {
	public int cost = 50;
	// Use this for initialization
	public override void Start () {
		base.Start();
		roundUp = GameObject.Find("SoldierRoundup");
		tower = GameObject.Find("EnemyTower");
		attackRadius = 2.0f;
		attackPower = 1;
		attackCooldown = .1f;
		speed = 10;
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
		GetComponent<Animator>().Play("Attack");
		targetEnemy.GetComponent<BaseCharacter>().health -= attackPower;
	}
}