using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerCooldown : MonoBehaviour {

	public Image loadingBar;
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
		loadingBar.fillAmount = currentValue / 100;
	}

	public void ResetCurrentValue()
	{
		Debug.Log("Resetting value");
		currentValue = 0;
	}
}
