using UnityEngine;
using System.Collections;

public class Constructor : MonoBehaviour {

	public Hex hex;
	public Map map;



	void Start () {
		map = GameObject.Find ("Generated_map").GetComponent <Map> ();
	}

	public void BuildBiology (Hex hex) {
		if (hex.hexType == 0) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 9;
		}
		if (hex.hexType == 1) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 11;
		}
		if (hex.hexType == 5) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 10;
		}
		if (hex.hexType == 6) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 12;
		}

	}
	public void BuildEnergy (Hex hex) {		
		if (hex.hexType == 0) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 13;
		}
		if (hex.hexType == 1) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 15;
		}
		if (hex.hexType == 5) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 14;
		}
		if (hex.hexType == 6) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 16;
		}
	}
	public void BuildEngineering (Hex hex) {		
		if (hex.hexType == 0) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 17;
		}
		if (hex.hexType == 1) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 19;
		}
		if (hex.hexType == 5) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 18;
		}
		if (hex.hexType == 6) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 20;
		}
	}
	public void BuildFactory (Hex hex) {		
		if (hex.hexType == 0) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 21;
		}
		if (hex.hexType == 1) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 23;
		}
		if (hex.hexType == 5) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 22;
		}
		if (hex.hexType == 6) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 24;
		}
	}
	public void BuildPhysics (Hex hex) {		
		if (hex.hexType == 0) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 33;
		}
		if (hex.hexType == 1) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 35;
		}
		if (hex.hexType == 5) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 34;
		}
		if (hex.hexType == 6) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 36;
		}
	}
	public void BuildSensor (Hex hex) {		
		if (hex.hexType == 0) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 37;
		}
		if (hex.hexType == 1) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 39;
		}
		if (hex.hexType == 5) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 38;
		}
		if (hex.hexType == 6) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 40;
		}
	}
}
