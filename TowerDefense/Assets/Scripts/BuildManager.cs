using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake()
	{
		if (instance != null) {
			Debug.LogError ("More than one instance of Gamemanager");
		}
		instance = this; 
	}

	public GameObject turrety;
	private GameObject turretToBuild;

	void Start()
	{
		turretToBuild = turrety;
	}



	public GameObject GetTurrerToBuild()
	{
	
		return turretToBuild;
	
	}
}
