using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public float health;
	// Use this for initialization
	void Start () {
		if(gameObject.name == "EnemyTower")
			health = 200;
		else
			health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
			Destroy(this.gameObject);
	}
}
