using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMonster : BaseCharacter {

	// Use this for initialization
	public override void Start () {
		base.Start();
		tower = GameObject.Find("PlayerTower");
		attackPower = 25;
		attackRadius = 2;
		attackCooldown = 3;
		speed = 3;
		health = 150;
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
