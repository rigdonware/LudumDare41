using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerCooldown : MonoBehaviour {

	public float currentValue;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(currentValue < 100)
		{
			currentValue += 33 * Time.deltaTime;
			gameObject.SetActive(true);
		}
		else
		{
			gameObject.SetActive(true);
		}
	}

	public void ResetCurrentValue()
	{
		Debug.Log("Resetting value");
		currentValue = 0;
	}
}
