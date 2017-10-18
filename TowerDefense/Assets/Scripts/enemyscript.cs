using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour {

	public float speed = 10f;
	private Transform target;
	private int wavepointindex = 0;
	void Start()
	{
		target = Waupointscript.points [0];

	}
	void Update()

	{
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime,Space.World ); 

		if(Vector3.Distance(transform.position,target.position)<= 0.4f ){
			getwaypoints ();
		}

	}
	void getwaypoints(){

		if (wavepointindex >= Waupointscript.points.Length - 1) {
			Destroy (gameObject);
		} else {
			wavepointindex++;
			target = Waupointscript.points [wavepointindex];
		}
	}
}
