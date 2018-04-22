using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : BaseCharacter {
	public int cost = 50;
	// Use this for initialization
	public override void Start () {
		base.Start();
		tower = GameObject.Find("EnemyTower");
		attackRadius = 3.0f;
		attackPower = 1;
		attackCooldown = .1f;
		speed = 10;
		health = 120;
		if(GameManager.instance.gameType == GameManager.RTS)
			roundUp = GameObject.Find("RobotRoundup");
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