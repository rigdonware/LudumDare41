using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Vector3 destination;
	float lifeSpan = 2f;
	float lifeCounter = 0f;
	public float damage = 10;
	public float speed;

	// Update is called once per frame
	void Update () {
		if(destination != Vector3.zero)
		{
			transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
		}
		lifeCounter += Time.deltaTime;
		if(lifeCounter >= lifeSpan)
		{
			Destroy(this.gameObject);
		}

	}

	void OnTriggerEnter(Collider other)
	{
		Destroy(this.gameObject);
	}


}
