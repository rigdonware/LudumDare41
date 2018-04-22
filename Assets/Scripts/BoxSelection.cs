using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSelection : MonoBehaviour {
	bool isSelecting = false;
	Vector3 startingPos;
	Ray ray;
	RaycastHit rayHit;
	GameObject clickedLocation;
	List<GameObject> selectedUnits;
	void Start()
	{
		selectedUnits = new List<GameObject>();
	}
	// Update is called once per frame
	void Update () {
		//if we are not in RTS mode then just return
		if(GameManager.instance && GameManager.instance.gameType != GameManager.RTS)
		{
			isSelecting = false;
			return;
		}

		if(Input.GetMouseButtonDown(0))
		{
			isSelecting = true;
			startingPos = Input.mousePosition;
		}
		if(Input.GetMouseButtonUp(0))
		{
			selectedUnits.Clear();
			foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
			{
				if(IsWithinSelectionBounds(obj))
				{
					selectedUnits.Add(obj);
				}
			}
			isSelecting = false;
		}

		if(Input.GetMouseButtonDown(1))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out rayHit))
			{
				clickedLocation = rayHit.collider.gameObject;
				if(clickedLocation)
					Debug.Log("Clicked " + clickedLocation.name);
				if(clickedLocation && clickedLocation.name == "Path" || clickedLocation.GetComponent<Tower>())
				{
					Debug.Log("Moving units");
					MoveSelectedUnits();
				}
			}
		}
	}

	void OnGUI()
	{
		if(isSelecting)
		{
			Rect rect = BoxSelectionGUI.GetScreenRect(startingPos, Input.mousePosition);
			BoxSelectionGUI.DrawBox(rect, new Color(.8f, .8f, .95f, .25f));
			BoxSelectionGUI.DrawScreenRectBorder(rect, 2, new Color(.8f, .8f, .95f, .25f));
		}
	}

	public bool IsWithinSelectionBounds(GameObject army)
	{
		if(!isSelecting)
		{
			return false;
		}

		Camera cam = Camera.main;
		Bounds bounds = BoxSelectionGUI.GetViewportBounds(cam, startingPos, Input.mousePosition);
		if(bounds.Contains(cam.WorldToViewportPoint(army.transform.position)))
			Debug.Log(army.name + " is in the selection area");
		return bounds.Contains(cam.WorldToViewportPoint(army.transform.position));
	}

	void MoveSelectedUnits()
	{
		Debug.Log("Amount of units selected: " + selectedUnits.Count);
		foreach(GameObject obj in selectedUnits)
		{
			if(obj)
			{
				if(obj.layer == LayerMask.NameToLayer("Soldier"))
				{
					if(clickedLocation.GetComponent<Tower>())
					{
						Debug.Log("clicked on tower");
						clickedLocation = obj.GetComponent<Soldier>().FindClosestDestination();
					}
					obj.GetComponent<Soldier>().targetDestination = clickedLocation;
				}
				else if(obj.layer == LayerMask.NameToLayer("Sniper"))
				{
					if(clickedLocation.GetComponent<Tower>())
						clickedLocation = obj.GetComponent<Sniper>().FindClosestDestination();
					obj.GetComponent<Sniper>().targetDestination = clickedLocation;
				}
				else if(obj.layer == LayerMask.NameToLayer("Robot"))
				{
					if(clickedLocation.GetComponent<Tower>())
						clickedLocation = obj.GetComponent<Robot>().FindClosestDestination();
					obj.GetComponent<Robot>().targetDestination = clickedLocation;
				}
			}
		}
	}
}
