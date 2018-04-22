using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	GameObject target;
	GameObject bullet;
	GameObject[] allTargets;
	bool canShoot = true;
	protected float range;
	protected float shootCooldown;
	protected int damage;
	float shootCounter = 0;
	// Use this for initialization
	public virtual void Start () {
		bullet = Resources.Load("Bullet") as GameObject;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		allTargets = GameObject.FindGameObjectsWithTag("Enemy");
		target = FindNearestTargetInRange();
		if(target)
		{
			Debug.Log("Found target");
			Vector3 targetDir = target.transform.position - transform.position;
			transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, targetDir, 5 * Time.deltaTime, 0.0f));
			if(canShoot)
			{
				canShoot = false;
				shootCounter = 0;
				Shoot();
			}
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
		Vector3 spawnPos = transform.Find("BulletSpawnPos").position;
		GameObject temp = (GameObject)Instantiate(bullet, spawnPos, Quaternion.identity);
		temp.GetComponent<Bullet>().destination = target.transform.position;
	}
}
