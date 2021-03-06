﻿using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;

	public GameObject bulletimpact;

	public float speed=70f;

	public void Seek(Transform _target)
	{
		target = _target;
	}
	
	// Update is called once per frame
	void Update () {

		if (target == null) {
			Destroy (gameObject);
			return;
		}
		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame) {
		
			HitTarget ();
		
		}

		transform.Translate (dir.normalized * distanceThisFrame,Space.World);
	}
	void HitTarget()
	{
		GameObject effect=(GameObject) Instantiate (bulletimpact, transform.position, transform.rotation);
		Destroy (effect, 2f);
		Destroy (target.gameObject);
		Destroy (gameObject);
	}
}
