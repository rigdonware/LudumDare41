using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : BaseCharacter {

	// Use this for initialization
	public override void Start () {
		base.Start();
		roundUp = GameObject.Find("SoldierRoundup");
		tower = GameObject.Find("EnemyTower");

		if(tower)
			Debug.Log("Found tower!");
		
		attackRadius = 5.0f;
		attackPower = 1;
		attackCooldown = .1f;
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
		GetComponent<Animator>().Play("Shooting");
	}
}
