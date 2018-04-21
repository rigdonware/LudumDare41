using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Vector3 destination;
	float lifeSpan = 3f;
	float lifeCounter = 0f;

	// Update is called once per frame
	void Update () {
		if(destination != Vector3.zero)
		{
			transform.position = Vector3.MoveTowards(transform.position, destination, 3 * Time.deltaTime);
		}
		lifeCounter += Time.deltaTime;
		if(lifeCounter >= lifeSpan)
		{
			Destroy(this.gameObject);
		}

	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Inside On trigger enter for bullet");
		Debug.Log("Collided with: " + other.gameObject.name);
		Destroy(this.gameObject);
	}
}
