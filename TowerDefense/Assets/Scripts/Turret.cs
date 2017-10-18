using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	private Transform target;

	[Header("Attributes")]
	public float range = 15f;
	public float fireRate=1f;

	private float firecountdown = 0f;

	[Header("Unity Setup fields")]
	public float turnspeed=10f ;
	public Transform partToRotate;  
	public string enemytag="Enemy";

	public GameObject bullet;
	public Transform firepoint;

	void Start()
	{
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemytag);
		GameObject nearestEnemy = null;
		float shortestDistance = Mathf.Infinity;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
		
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}

		}
		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
		//	targetEnemy = nearestEnemy.GetComponent<Enemy>();
		} else
		{
			target = null;
		}

	}
	void Update()

	{
	 
		if (target == null)
			return; 

		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation ,lookRotation,Time.deltaTime * turnspeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);

		if (firecountdown <= 0f) {
			Shoot ();
			firecountdown = 1f / fireRate;

		}
		firecountdown -= Time.deltaTime;


	}

	void Shoot()
	{
		GameObject bulletGO=(GameObject)Instantiate (bullet, firepoint.position, firepoint.rotation); 
		Bullet bulleti = bulletGO.GetComponent<Bullet> ();

		if (bulleti != null) {
			bulleti.Seek (target);
		}
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
