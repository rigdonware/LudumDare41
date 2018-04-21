using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject[] destinations;
	public static GameManager instance = null;

	// Use this for initialization
	void Start () {
		destinations = GameObject.FindGameObjectsWithTag("Destination");
	}
	
	// Update is called once per frame
	void Update () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
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
