using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wavespawner : MonoBehaviour {

	public Transform enemyprefab;
	public Transform spawnpoint;
	public float timeBetweenwaves = 5f;
	private float countdown = 2f;
	private int wavenumber = 0;

	public Text wavecountdowntext;

	void Update () {
		if(countdown<= 0f)
		{
			StartCoroutine (SpawnWave ());
			countdown = timeBetweenwaves;
		}
		countdown -= Time.deltaTime;
		wavecountdowntext.text = Mathf.Round (countdown).ToString();
	}
	IEnumerator SpawnWave(){
	 
		wavenumber++;
		for (int i = 0; i < wavenumber; i++) {
			SpawnEnemy ();
		}


		yield return  new WaitForSeconds (0.5f);
	
	}
	void SpawnEnemy()
	{
		Instantiate (enemyprefab,spawnpoint.position,spawnpoint.rotation);
	}

}
