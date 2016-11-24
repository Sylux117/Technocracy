using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CityManagement : MonoBehaviour {

	public GameObject canvas;
	public Hex hex;
	public int range = 3;

	public int cityLevel;
	public float food;
	public float production;
	public float biology;
	public float physics;
	public float engineering;


	void Start () {
		canvas = GameObject.Find("CityCanvas").gameObject;
		canvas.SetActive (false);
		hex = this.gameObject.GetComponent <Hex> ();
		cityLevel = 1;
	}

	void Update () {
		if (hex.isSelected == true) {
			canvas.SetActive (true);
		} else {
			canvas.SetActive (false);
		}
		if (food >= 200) {
			cityLevel = 2;
		}
		if (food >= 800) {
			cityLevel = 3;
		}
	}

	public void CityLeveler (float foodPerTurn, float productionPerTurn, float biologyPerTurn, float physicsPerTurn, float engineeringPerTurn) {
		food += foodPerTurn;
		production += productionPerTurn;
		biology += biologyPerTurn;
		physics += physicsPerTurn;
		engineering += engineeringPerTurn;
	}


}
