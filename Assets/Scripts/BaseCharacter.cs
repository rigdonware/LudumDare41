using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour {

	GameObject destination;
	public GameObject[] destinations;
	public List<GameObject> visitedDestinations;
	// Use this for initialization
	void Start () {
		//set it to the amount of destinations there are
		destinations = GameObject.FindGameObjectsWithTag("Destination");
	}
	
	// Update is called once per frame
	void Update () {
		if(!destination)
			destination = FindClosestDestination(this.gameObject);
		if(destination)
		{
			//transform.Translate(destination.transform.position.x * Time.deltaTime, destination.transform.position.y * Time.deltaTime, destination.transform.position.z * Time.deltaTime);
			transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, 2 * Time.deltaTime);
			if(transform.position == destination.transform.position)
				destination = null;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Bullet")
		{
			Destroy(this.gameObject);
		}
	}

	public GameObject FindClosestDestination(GameObject player)
	{
		GameObject destination = null;

		float closestDistance = float.MaxValue;

		foreach(GameObject dest in destinations)
		{
			float distance = Vector3.Distance(dest.transform.position, player.transform.position);
			if(distance < closestDistance && !player.GetComponent<BaseCharacter>().visitedDestinations.Contains(dest))
			{
				closestDistance = distance;
				destination = dest;
			}
		}
		player.GetComponent<BaseCharacter>().visitedDestinations.Add(destination);
		return destination;
	}
}
