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
				{
					Debug.Log("Clicked " + clickedObject.name);
					if(clickedObject.GetComponent<Node>())
					{
						if(!clickedObject.GetComponent<Node>().occupied && selectedTurret)
						{
							GameObject temp = (GameObject)Instantiate(selectedTurret, clickedObject.transform.position, Quaternion.identity);
							if(temp)
								Debug.Log("Placed a turret");
							selectedTurret = null;
						}
					}
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			selectedTurret = turretPrefab;
			if(selectedTurret)
				Debug.Log("Selected a turret");
		}
	}
}
