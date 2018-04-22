using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	GameObject sniperTurret;
	GameObject standardTurret;
	GameObject heavyTurret;
	Ray ray;
	RaycastHit rayHit;
	GameObject clickedObject;
	GameObject selectedTurret;
	// Use this for initialization
	void Start () {
		sniperTurret = Resources.Load("SniperTurret") as GameObject;
		standardTurret = Resources.Load("StandardTurret") as GameObject;
		heavyTurret = Resources.Load("HeavyTurret") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out rayHit))
			{
				clickedObject = rayHit.collider.gameObject;
				if(clickedObject)
					Debug.Log("Clicked " + clickedObject.name);
				if(clickedObject && clickedObject.GetComponent<Node>())
				{
					SpawnSelectedTurret();
				}
			}
		}

		if(Input.GetMouseButtonDown(1))
		{
			//if the selected object is a scout
			if(clickedObject && clickedObject.GetComponent<Scout>())
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if(Physics.Raycast(ray, out rayHit))
				{
					GameObject material = rayHit.collider.gameObject;
					//and the user right clicks on the brick or the steel
					if(material.gameObject.name == "Brick" || material.gameObject.name == "Steel")
					{
						clickedObject.GetComponent<Scout>().SetTargetMaterial(material);
					}
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			selectedTurret = standardTurret;
		}

		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			selectedTurret = sniperTurret;
		}

		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			selectedTurret = heavyTurret;
		}
	}

	void SpawnSelectedTurret()
	{
		if(!selectedTurret)
			return;

		int cost = 0;
		switch(selectedTurret.name)
		{
		case "SniperTurret":
			cost = selectedTurret.GetComponent<SniperTurret>().cost;
			break;
		case "StandardTurret":
			cost = selectedTurret.GetComponent<StandardTurret>().cost;
			break;
		case "HeavyTurret":
			cost = selectedTurret.GetComponent<HeavyTurret>().cost;
			break;
		}

		if(GameManager.instance.steel < cost)
		{
			GameManager.instance.DisplayWarning("Not enough steel");
			selectedTurret = null;
			return;
		}
		if(!clickedObject.GetComponent<Node>().occupied)
		{
			float yPos = clickedObject.transform.position.y + clickedObject.GetComponent<Renderer>().bounds.size.y;
			Vector3 turretSpawnPos = new Vector3(clickedObject.transform.position.x, yPos, clickedObject.transform.position.z);
			GameManager.instance.IncreaseSteel(cost * -1);
			clickedObject.GetComponent<Node>().occupied = true;
			GameObject temp = (GameObject)Instantiate(selectedTurret, turretSpawnPos, Quaternion.identity);
		}
		selectedTurret = null;
	}
}
