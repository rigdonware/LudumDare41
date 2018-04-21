using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	GameObject turretPrefab;
	Ray ray;
	RaycastHit rayHit;
	GameObject clickedObject;
	GameObject selectedTurret;
	// Use this for initialization
	void Start () {
		turretPrefab = Resources.Load("Turret") as GameObject;
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
					SpawnSelectedTurret();
			}
		}

		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			selectedTurret = turretPrefab;
			if(selectedTurret)
				Debug.Log("Selected a turret");
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
				obj.GetComponent<BaseCharacter>().attacking = true;
			}
		}
	}

	void SpawnSelectedTurret()
	{
		Debug.Log("Clicked " + clickedObject.name);
		if(clickedObject.GetComponent<Node>())
		{
			if(!clickedObject.GetComponent<Node>().occupied && selectedTurret)
			{
				float yPos = clickedObject.transform.position.y + clickedObject.GetComponent<Renderer>().bounds.size.y;
				Vector3 turretSpawnPos = new Vector3(clickedObject.transform.position.x, yPos, clickedObject.transform.position.z);
				GameObject temp = (GameObject)Instantiate(selectedTurret, turretSpawnPos, Quaternion.identity);
				if(temp)
					Debug.Log("Placed a turret");
				selectedTurret = null;
			}
		}
	}
}
