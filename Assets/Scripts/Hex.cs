using UnityEngine;
using System.Collections.Generic;

public class Hex : MonoBehaviour {

	public int x;
	public int y;
	public int building;

	public bool isSelected;

	public int turnCount;

	public bool isBuilding;
	public Map map;
	public int hexType;

	public float food;
	public float production;
	public float biology;
	public float physics;
	public float engineering;
	public bool gold;
	public bool silver;

	void Start () {
		isSelected = false;
		map = GameObject.Find ("Generated_map").GetComponent <Map> ();
		hexType = map.hexType [x + (y * 40)];
		CalculateResources ();
	}

	void Update () {
		if (isSelected == true) {
			transform.FindChild ("Particle System").gameObject.SetActive (true);
		} else if (isSelected == false) {
			transform.FindChild ("Particle System").gameObject.SetActive (false);
		}

		if (turnCount == 5) {
			GameObject.Find ("MouseManager").GetComponent <MouseManager> ().canBuild = true;
			GameObject.Find ("MouseManager").GetComponent <NextTurnManager> ().RemoveBuilding(this.gameObject);
			map.ChangeHexes (building, this);
		}
	}

	public void CalculateResources () {
		#region Resources

		if (hexType == 0 || hexType == 9 || hexType == 13 || hexType == 17 || hexType == 21 || hexType == 29 ||  hexType == 33 || hexType == 37 || hexType == 41 || hexType == 45 || hexType == 49) {
			food += 2;
		}
		if (hexType == 5 || hexType == 10 || hexType == 14 || hexType == 18 || hexType == 22 || hexType == 30 ||  hexType == 34 || hexType == 38 || hexType == 42 || hexType == 46 || hexType == 50) {
			food += 2;
			production += 1;
		}
		if (hexType == 1 || hexType == 11 || hexType == 15 || hexType == 19 || hexType == 23 || hexType == 31 || hexType == 35 || hexType == 39 || hexType == 43 || hexType == 47 || hexType == 51) {
			food += 1;
			production += 1;
		}
		if (hexType == 6 || hexType == 12 || hexType == 16 || hexType == 20 || hexType == 24 || hexType == 32 ||  hexType == 36 || hexType == 40 || hexType == 44 || hexType == 48 || hexType == 52) {
			food += 2;
		}
		if (hexType == 4) {
			food += 2;
			production += 1;
		}
		if (hexType == 25) {
			food += 2;
			production += 1;
		}
		if (hexType == 26) {
			food += 2;
			production += 2;
		}
		if (hexType == 27) {
			food += 1;
			production += 2;
		}
		if (hexType == 28) {
			food += 1;
			production += 3;
		}

		if (hexType == 9 || hexType == 10 || hexType == 11 || hexType == 12) {
			biology += 10;
		}

		if (hexType == 17 || hexType == 18 || hexType == 19 || hexType == 20) {
			engineering += 10;
		}

		if (hexType == 21 || hexType == 22 || hexType == 23 || hexType == 24) {
			production += 2;
		}

		if (hexType == 45 || hexType == 46 || hexType == 47 || hexType == 48) {
			food += 2;
		}

		if (hexType == 33 || hexType == 34 || hexType == 35 || hexType == 36) {
			physics += 10;
		}

		#endregion
	}
}
