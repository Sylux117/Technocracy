using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NextTurnManager : MonoBehaviour {

	int turnCount;
	public GameObject[] units;
	public Text turnNumber;
	public List <GameObject> building;


	void Start () {
		turnCount = 0;
		units = null;
		building = new List <GameObject> ();
	}

	void Update () {
		units = GameObject.FindGameObjectsWithTag ("Unit");
	}

	public void NextTurn () {

		for (int i = 0; i < units.Length; i++) {
			units [i].GetComponent <Unit> ().MoveNextHex ();
		}

		for (int i = 0; i < building.Count; i++) {
			building [i].gameObject.GetComponent <Hex> ().turnCount++;
		}

		turnCount++;
		ShowTurn ();
	}

	public void ShowTurn () {
		turnNumber.text = "Turn " + turnCount;
	}

	public void AddBuilding (GameObject build) {
		building.Add (build.gameObject);
	}

	public void RemoveBuilding (GameObject build) {
		for (int i = 0; i < building.Count; i++) {
			if (building[i] == build){
				building.RemoveAt (i);
			}
		}
	}
}
