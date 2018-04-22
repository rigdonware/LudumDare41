using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : MonoBehaviour {

	GameObject targetMaterial;
	GameObject targetDestination;
	GameObject tower;
	bool atTargetMaterial;
	float amountOfMaterialsHarvested;
	// Use this for initialization
	void Start () {
		atTargetMaterial = false;
		tower = GameObject.Find("PlayerTower");
	}
	
	// Update is called once per frame
	void Update () {
		if(!atTargetMaterial && targetDestination)
		{
			//go to it
			GetComponent<Animator>().Play("Walking");
			Vector3 targetDir = targetDestination.transform.position - transform.position;
			transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, targetDir, 2 * Time.deltaTime, 0.0f));
			transform.position = Vector3.MoveTowards(transform.position, targetDestination.transform.position, 2 * Time.deltaTime);
		}
			
		//if you are at the target material, harvest/play animation
		if(atTargetMaterial)
		{
			GetComponent<Animator>().Play("PickUp");
			amountOfMaterialsHarvested += Time.deltaTime;
			Debug.Log("Amount of materials: " + amountOfMaterialsHarvested);
		}

		if(amountOfMaterialsHarvested >= 3)
		{
			Debug.Log("Materials harvested, time to return back to the tower");
			atTargetMaterial = false;
			targetDestination = tower;
		}
	}

	public void SetTargetMaterial(GameObject material)
	{
		targetDestination = targetMaterial = material;
		atTargetMaterial = false;
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Inside on trigger enter for scout");
		if(other.gameObject.name == targetMaterial.name)
		{
			Debug.Log("At target material");
			atTargetMaterial = true;
		}

		if(other.gameObject.name == "PlayerTower")
		{
			targetDestination = targetMaterial;
			GameManager.instance.brick += (int)amountOfMaterialsHarvested;
			amountOfMaterialsHarvested = 0;
			Debug.Log("You now have " + GameManager.instance.brick + " brick.");
		}
	}
}
