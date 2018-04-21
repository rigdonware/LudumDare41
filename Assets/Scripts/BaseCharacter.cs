using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour {

	GameObject destination;
	public List<GameObject> visitedDestinations;
	// Use this for initialization
	void Start () {
		//set it to the amount of destinations there are
	}
	
	// Update is called once per frame
	void Update () {
		if(!destination)
			destination = GameManager.instance.FindClosestDestination(this.gameObject);
		if(destination)
		{
			//transform.Translate(destination.transform.position.x * Time.deltaTime, destination.transform.position.y * Time.deltaTime, destination.transform.position.z * Time.deltaTime);
			transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, 10 * Time.deltaTime);
			if(transform.position == destination.transform.position)
				destination = null;
		}
	}
}
