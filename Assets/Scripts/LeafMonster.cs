using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafMonster : BaseCharacter {

	// Use this for initialization
	public override void Start () {
		base.Start();
		tower = GameObject.Find("PlayerTower");
		attackPower = 10;
		attackRadius = 3;
		attackCooldown = .5f;
		speed = 8;
		health = 75;
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
