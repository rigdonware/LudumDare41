using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseCharacter : MonoBehaviour {

	protected GameObject destination;
	protected GameObject tower = null;
	protected GameObject bullet;
	public GameObject[] destinations;
	public List<GameObject> visitedDestinations;
	protected float attackRadius;
	protected float attackPower;
	protected float attackCooldown;
	float attackTimer = 0;
	bool canAttack = true;
	public float speed;
	public GameObject[] enemies;
	public GameObject targetEnemy;
	public float health = 100;
	protected float maxHealth = 100;
	public Image healthBar;
	public bool attacking;
	public GameObject roundUp;
	protected bool attackingCastle = false;
	protected Rigidbody rb;

	// Use this for initialization
	public virtual void Start () {
		//set it to the amount of destinations there are
		destinations = GameObject.FindGameObjectsWithTag("Destination");
		bullet = Resources.Load("Bullet") as GameObject;
		rb = GetComponent<Rigidbody>();
		//healthBar = transform.Find("HealthBar").Find("Image").GetComponent<Image>();
		if(gameObject.tag == "Player")
			attacking = true;
		else
			attacking = true;
	}

	
	// Update is called once per frame
	public virtual void Update () {
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
				transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, speed * Time.deltaTime);
				transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, targetDir, speed * Time.deltaTime, 0.0f));
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

		attackTimer += Time.deltaTime;
		if(attackTimer >= attackCooldown)
		{
			canAttack = true;
		}

		if(!targetEnemy)
			targetEnemy = FindClosestEnemy();
		
		if(targetEnemy)
		{
			Debug.Log("There is an enemy");
			transform.Translate(Vector3.zero);
			rb.velocity = Vector3.zero;
			if(canAttack)
			{
				AttackEnemy();
				attackTimer = 0;
				canAttack = false;
			}
		}
		//we have made it to the last node, now go to the castle and attack it
		else if(visitedDestinations.Count > destinations.Length && !targetEnemy)
		{
			destination = null;
			transform.Translate(Vector3.zero);
			rb.velocity = Vector3.zero;
			gameObject.GetComponent<Animator>().Play("Attack");
			if(canAttack)
			{
				AttackTower();
				attackTimer = 0;
				canAttack = false;
			}
		}

		if(health <= 0)
		{
			if(gameObject.tag == "Enemy")
				GameManager.instance.IncreaseGold(20);
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log("Inside on trigger enter");
		if(other.gameObject.tag == "Bullet" && other.gameObject.layer != LayerMask.NameToLayer(this.gameObject.tag))
		{
			//Debug.Log("Collided with enemy");
			health -= other.gameObject.GetComponent<Bullet>().damage;
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

	public virtual void AttackEnemy()
	{
		
		//targetEnemy.GetComponent<BaseCharacter>().health -= attackPower;
		//targetEnemy.GetComponent<BaseCharacter>().healthBar.fillAmount = health;
	}

	public void AttackTower()
	{
		Debug.Log("Attacking tower");
		if(tower)
			tower.GetComponent<Tower>().health -= attackPower;
	}
}
