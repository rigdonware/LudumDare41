using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	GameObject target;
	GameObject bullet;
	GameObject[] allTargets;
	bool canShoot = true;
	float range = 10.0f;
	float shootCooldown = 1;
	float shootCounter = 0;
	public int cost = 10;
	// Use this for initialization
	void Start () {
		bullet = Resources.Load("Bullet") as GameObject;	
	}
	
	// Update is called once per frame
	void Update () {
		allTargets = GameObject.FindGameObjectsWithTag("Enemy");
		target = FindNearestTargetInRange();
		if(target && canShoot)
		{
			canShoot = false;
			shootCounter = 0;
			Shoot();
		}

		shootCounter += Time.deltaTime;
		if(shootCounter >= shootCooldown)
			canShoot = true;

	}

	GameObject FindNearestTargetInRange()
	{
		GameObject closestTarget = null;
		float closest = float.MaxValue;
		foreach(GameObject enemy in allTargets)
		{
			float distance = Vector3.Distance(enemy.transform.position, transform.position);
			if(distance < closest && distance <= range)
			{
				closest = distance;
				closestTarget = enemy;
			}
		}
		return closestTarget;
	}

	void Shoot()
	{
		Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
		GameObject temp = (GameObject)Instantiate(bullet, spawnPos, Quaternion.identity);
		temp.GetComponent<Bullet>().destination = target.transform.position;
	}
}
