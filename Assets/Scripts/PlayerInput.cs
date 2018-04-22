using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	GameObject sniperTurret;
	Ray ray;
	RaycastHit rayHit;
	GameObject clickedObject;
	GameObject selectedTurret;
	// Use this for initialization
	void Start () {
		sniperTurret = Resources.Load("SniperTurret") as GameObject;
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
				Debug.Log("Selected the scout and now right clicking");
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
			selectedTurret = sniperTurret;
		}

		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			//GameObject.Find("PlayerTower").GetComponent<PlayerSpawner>().QueueUpArmy(Resources.Load("Player") as GameObject);
		}

		if(Input.GetKeyDown(KeyCode.A))
		{
			GameObject[] army = GameObject.FindGameObjectsWithTag("Player");
			foreach(GameObject obj in army)
			{
				//obj.GetComponent<BaseCharacter>().attacking = true;
				switch(LayerMask.LayerToName(obj.layer))
				{
				case "Soldier":
					obj.GetComponent<Soldier>().attacking = true;
					break;
				case "Sniper":
					obj.GetComponent<Sniper>().attacking = true;
					break;
				case "Robot":
					obj.GetComponent<Robot>().attacking = true;
					break;
				case "RockMonster":
					obj.GetComponent<RockMonster>().attacking = true;
					break;
				case "LeafMonster":
					obj.GetComponent<LeafMonster>().attacking = true;
					break;
				}
			}
		}
	}

	void SpawnSelectedTurret()
	{
		

		if(!clickedObject.GetComponent<Node>().occupied && selectedTurret && selectedTurret.GetComponent<Turret>().cost <= GameManager.instance.gold)
		{
			float yPos = clickedObject.transform.position.y + clickedObject.GetComponent<Renderer>().bounds.size.y;
			Vector3 turretSpawnPos = new Vector3(clickedObject.transform.position.x, yPos, clickedObject.transform.position.z);
			GameManager.instance.IncreaseGold(selectedTurret.GetComponent<Turret>().cost * -1);
			GameObject temp = (GameObject)Instantiate(selectedTurret, turretSpawnPos, Quaternion.identity);
		}
		selectedTurret = null;
	}
}
