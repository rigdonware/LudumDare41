using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	float speed = 2;
	Vector3 dragOrigin;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(2))
		{
			dragOrigin = Input.mousePosition;
			return;
		}

		if(!Input.GetMouseButton(2))
			return;

		Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
		Vector3 move = new Vector3( pos.z * speed, 0,  pos.x * speed);
		transform.Translate(move, Space.World);
	}
}
