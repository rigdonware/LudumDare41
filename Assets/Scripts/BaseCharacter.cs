using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseCharacter : MonoBehaviour {

	GameObject destination;
	public GameObject[] destinations;
	public List<GameObject> visitedDestinations;
	float attackRadius = 5.0f;
	float attackPower = 0;
	public GameObject[] enemies;
	public GameObject targetEnemy;
	public float health = 100;
	float maxHealth = 100;
	public Image healthBar;
	public bool attacking;
	public GameObject roundUp;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		//set it to the amount of destinations there are
		destinations = GameObject.FindGameObjectsWithTag("Destination");
		rb = GetComponent<Rigidbody>();
		attackPower = Random.Range(10, 20);
		//healthBar = transform.Find("HealthBar").Find("Image").GetComponent<Image>();

		if(gameObject.tag == "Player")
		{
			attacking = false;
			if(LayerMask.LayerToName(gameObject.layer) == "Soldier")
			{
				roundUp = GameObject.Find("SoldierRoundup");
			}
			else if(LayerMask.LayerToName(gameObject.layer) == "Sniper")
			{
				roundUp = GameObject.Find("SniperRoundup");
			}
		}
		else
			attacking = true;
	}

	
	// Update is called once per frame
	void Update () {
		if(gameObject.tag == "Player")
			enemies = GameObject.FindGameObjectsWithTag("Enemy");
		else
			enemies = GameObject.FindGameObjectsWithTag("Player");

		if(attacking)
		{
			if(!destination)
				destination = FindClosestDestination();
			if(destination && !targetEnemy)
			{
				//transform.Translate(destination.transform.position.x * Time.deltaTime, destination.transform.position.y * Time.deltaTime, destination.transform.position.z * Time.deltaTime);
				Vector3 targetDir = destination.transform.position - transform.position;
				transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, 3 * Time.deltaTime);
				transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, targetDir, 3 * Time.deltaTime, 0.0f));
				if(transform.position == destination.transform.position)
					destination = null;
			}
		}

		if(!attacking && roundUp)
		{
			destination = roundUp;
			Vector3 size = destination.GetComponent<BoxCollider>().bounds.size;
			Vector3 location = new Vector3(destination.transform.position.x + Random.Range(0, size.x), destination.transform.position.y, destination.transform.position.z + Random.Range(0, size.z));
			transform.position = Vector3.MoveTowards(transform.position, location, 3 * Time.deltaTime);
			if(transform.position == destination.transform.position)
				roundUp = null;
		}

		if(!targetEnemy)
			targetEnemy = FindClosestEnemy();
		if(targetEnemy)
		{
			AttackEnemy();
			transform.Translate(Vector3.zero);
			if(targetEnemy.GetComponent<BaseCharacter>().health <= 0)
			{
				Destroy(targetEnemy);
				GameManager.instance.IncreaseGold(20);
			}
		}
		else
		{
			GetComponent<Animator>().Play("Walking");
		}

		if(health <= 0)
			Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log("Inside on trigger enter");
		if(other.gameObject.tag == "Bullet")
		{
			Debug.Log("Collided with enemy");
			Destroy(this.gameObject);
		}
	}

	public GameObject FindClosestDestination()
	{
		GameObject destination = null;

		float closestDistance = float.MaxValue;

		foreach(GameObject dest in destinations)
		{
			float distance = Vector3.Distance(dest.transform.position, transform.position);
			if(distance < closestDistance && !visitedDestinations.Contains(dest))
			{
				closestDistance = distance;
				destination = dest;
			}
		}
		visitedDestinations.Add(destination);
		return destination;
	}

	public GameObject FindClosestEnemy()
	{
		GameObject target = null;
		float closestDistance = float.MaxValue;

		foreach(GameObject enemy in enemies)
		{
			float distance = Vector3.Distance(enemy.transform.position, transform.position);
			if(distance < closestDistance && distance < attackRadius)
			{
				closestDistance = distance;
				target = enemy;
			}
		}
		return target;
	}

	void AttackEnemy()
	{
		targetEnemy.GetComponent<BaseCharacter>().health -= attackPower * Time.deltaTime;
		if(LayerMask.LayerToName(gameObject.layer) == "Soldier")
		{
			GetComponent<Animator>().Play("Shooting");
		}
		else if(LayerMask.LayerToName(gameObject.layer) == "Sniper")
		{
			GetComponent<Animator>().Play("Sniping");
		}

		//targetEnemy.GetComponent<BaseCharacter>().healthBar.fillAmount = health;
	}
}
