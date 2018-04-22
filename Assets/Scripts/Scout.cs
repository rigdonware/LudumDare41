using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : MonoBehaviour {

	GameObject targetMaterial;
	GameObject targetDestination;
	GameObject tower;
	bool atTargetMaterial;
	float amountOfMaterialsHarvested;
	public int cost = 100;
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
			transform.position = Vector3.MoveTowards(transform.position, targetDestination.transform.position, 4 * Time.deltaTime);
		}
			
		//if you are at the target material, harvest/play animation
		if(atTargetMaterial)
		{
			GetComponent<Animator>().Play("PickUp");
			amountOfMaterialsHarvested +=  2 * Time.deltaTime;
		}

		if(amountOfMaterialsHarvested >= 10)
		{
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
		if(other.gameObject.name == targetMaterial.name)
		{
			atTargetMaterial = true;
		}

		if(other.gameObject.name == "PlayerTower")
		{
			targetDestination = targetMaterial;
			if(targetMaterial.name == "Brick")
				GameManager.instance.IncreaseBrick((int)amountOfMaterialsHarvested);
			else if(targetMaterial.name == "Steel")
				GameManager.instance.IncreaseSteel((int)amountOfMaterialsHarvested);
			
			amountOfMaterialsHarvested = 0;
		}
	}
}
