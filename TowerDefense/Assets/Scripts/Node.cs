using UnityEngine;

public class Node : MonoBehaviour {

	public Color hoverColor;

	private Renderer rend;

	public Vector3 positionOffset;

	private GameObject turret;

	private Color startColor;

	void Start()
	{
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
	
	}

	void OnMouseEnter()
	{
		rend.material.color = hoverColor;
	}

	void OnMouseDown()
	{
		if (turret != null) {
			Debug.Log ("Cant build a turret");
			return;
		}

		GameObject turretBuild = BuildManager.instance.GetTurrerToBuild ();
		turret=(GameObject)  Instantiate (turretBuild, transform.position+ positionOffset, transform.rotation);

	} 

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}

}
