﻿using UnityEngine;
using System.Collections.Generic;

public class Hex : MonoBehaviour {

	public int x;
	public int y;
	public int building;

	public bool isSelected;

	public int turnCount;

	public bool isBuilding;
	public Map map;

	void Start () {
		isSelected = false;
		map = GameObject.Find ("Generated_map").GetComponent <Map> ();
	}

	void Update () {
		if (isSelected == true) {
			transform.FindChild ("Particle System").gameObject.SetActive (true);
		} else if (isSelected == false) {
			transform.FindChild ("Particle System").gameObject.SetActive (false);
		}

		if (turnCount == 5) {
			GameObject.Find ("MouseManager").GetComponent <NextTurnManager> ().RemoveBuilding(this.gameObject);
			map.ChangeHexes (building, this);
		}
	}
}