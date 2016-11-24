using UnityEngine;
using System.Collections;

public class Constructor : MonoBehaviour {

	public Hex hex;
	public Map map;



	void Start () {
		map = GameObject.Find ("Generated_map").GetComponent <Map> ();
	}

	public void BuildBiology (Hex hex) {
		if (hex.hexType == 0 || hex.hexType == 9 || hex.hexType == 13 || hex.hexType == 17 || hex.hexType == 21 || hex.hexType == 25 || hex.hexType == 29 ||  hex.hexType == 33 || hex.hexType == 37 || hex.hexType == 41) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 9;
		}
		if (hex.hexType == 1 || hex.hexType == 11 || hex.hexType == 15 || hex.hexType == 19 || hex.hexType == 23 || hex.hexType == 27 || hex.hexType == 31 || hex.hexType == 35 || hex.hexType == 39 || hex.hexType == 43) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 11;
		}
		if (hex.hexType == 5 || hex.hexType == 10 || hex.hexType == 14 || hex.hexType == 18 || hex.hexType == 22 || hex.hexType == 26 || hex.hexType == 30 ||  hex.hexType == 34 || hex.hexType == 38 || hex.hexType == 42) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 10;
		}
		if (hex.hexType == 6 || hex.hexType == 12 || hex.hexType == 16 || hex.hexType == 20 || hex.hexType == 24 || hex.hexType == 28 || hex.hexType == 32 ||  hex.hexType == 36 || hex.hexType == 40 || hex.hexType == 44) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 12;
		}

	}

	public void BuildEnergy (Hex hex) {		
		if (hex.hexType == 0 || hex.hexType == 9 || hex.hexType == 13 || hex.hexType == 17 || hex.hexType == 21 || hex.hexType == 25 || hex.hexType == 29 ||  hex.hexType == 33 || hex.hexType == 37 || hex.hexType == 41) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 13;
		}
		if (hex.hexType == 1 || hex.hexType == 11 || hex.hexType == 15 || hex.hexType == 19 || hex.hexType == 23 || hex.hexType == 27 || hex.hexType == 31 || hex.hexType == 35 || hex.hexType == 39 || hex.hexType == 43) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 15;
		}
		if (hex.hexType == 5 || hex.hexType == 10 || hex.hexType == 14 || hex.hexType == 18 || hex.hexType == 22 || hex.hexType == 26 || hex.hexType == 30 ||  hex.hexType == 34 || hex.hexType == 38 || hex.hexType == 42) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 14;
		}
		if (hex.hexType == 6 || hex.hexType == 12 || hex.hexType == 16 || hex.hexType == 20 || hex.hexType == 24 || hex.hexType == 28 || hex.hexType == 32 ||  hex.hexType == 36 || hex.hexType == 40 || hex.hexType == 44) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 16;
		}
	}

	public void BuildEngineering (Hex hex) {		
		if (hex.hexType == 0 || hex.hexType == 9 || hex.hexType == 13 || hex.hexType == 17 || hex.hexType == 21 || hex.hexType == 25 || hex.hexType == 29 ||  hex.hexType == 33 || hex.hexType == 37 || hex.hexType == 41) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 17;
		}
		if (hex.hexType == 1 || hex.hexType == 11 || hex.hexType == 15 || hex.hexType == 19 || hex.hexType == 23 || hex.hexType == 27 || hex.hexType == 31 || hex.hexType == 35 || hex.hexType == 39 || hex.hexType == 43) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 19;
		}
		if (hex.hexType == 5 || hex.hexType == 10 || hex.hexType == 14 || hex.hexType == 18 || hex.hexType == 22 || hex.hexType == 26 || hex.hexType == 30 ||  hex.hexType == 34 || hex.hexType == 38 || hex.hexType == 42) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 18;
		}
		if (hex.hexType == 6 || hex.hexType == 12 || hex.hexType == 16 || hex.hexType == 20 || hex.hexType == 24 || hex.hexType == 28 || hex.hexType == 32 ||  hex.hexType == 36 || hex.hexType == 40 || hex.hexType == 44) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 20;
		}
	}

	public void BuildFactory (Hex hex) {		
		if (hex.hexType == 0 || hex.hexType == 9 || hex.hexType == 13 || hex.hexType == 17 || hex.hexType == 21 || hex.hexType == 25 || hex.hexType == 29 ||  hex.hexType == 33 || hex.hexType == 37 || hex.hexType == 41) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 21;
		}
		if (hex.hexType == 1 || hex.hexType == 11 || hex.hexType == 15 || hex.hexType == 19 || hex.hexType == 23 || hex.hexType == 27 || hex.hexType == 31 || hex.hexType == 35 || hex.hexType == 39 || hex.hexType == 43) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 23;
		}
		if (hex.hexType == 5 || hex.hexType == 10 || hex.hexType == 14 || hex.hexType == 18 || hex.hexType == 22 || hex.hexType == 26 || hex.hexType == 30 ||  hex.hexType == 34 || hex.hexType == 38 || hex.hexType == 42) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 22;
		}
		if (hex.hexType == 6 || hex.hexType == 12 || hex.hexType == 16 || hex.hexType == 20 || hex.hexType == 24 || hex.hexType == 28 || hex.hexType == 32 ||  hex.hexType == 36 || hex.hexType == 40 || hex.hexType == 44) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 24;
		}
	}

	public void BuildFarm (Hex hex) {		
		if (hex.hexType == 0 || hex.hexType == 9 || hex.hexType == 13 || hex.hexType == 17 || hex.hexType == 21 || hex.hexType == 25 || hex.hexType == 29 ||  hex.hexType == 33 || hex.hexType == 37 || hex.hexType == 41) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 45;
		}
		if (hex.hexType == 1 || hex.hexType == 11 || hex.hexType == 15 || hex.hexType == 19 || hex.hexType == 23 || hex.hexType == 27 || hex.hexType == 31 || hex.hexType == 35 || hex.hexType == 39 || hex.hexType == 43) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 47;
		}
		if (hex.hexType == 5 || hex.hexType == 10 || hex.hexType == 14 || hex.hexType == 18 || hex.hexType == 22 || hex.hexType == 26 || hex.hexType == 30 ||  hex.hexType == 34 || hex.hexType == 38 || hex.hexType == 42) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 46;
		}
		if (hex.hexType == 6 || hex.hexType == 12 || hex.hexType == 16 || hex.hexType == 20 || hex.hexType == 24 || hex.hexType == 28 || hex.hexType == 32 ||  hex.hexType == 36 || hex.hexType == 40 || hex.hexType == 44) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 48;
		}
	}

	public void BuildPhysics (Hex hex) {		
		if (hex.hexType == 0 || hex.hexType == 9 || hex.hexType == 13 || hex.hexType == 17 || hex.hexType == 21 || hex.hexType == 25 || hex.hexType == 29 ||  hex.hexType == 33 || hex.hexType == 37 || hex.hexType == 41) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 33;
		}
		if (hex.hexType == 1 || hex.hexType == 11 || hex.hexType == 15 || hex.hexType == 19 || hex.hexType == 23 || hex.hexType == 27 || hex.hexType == 31 || hex.hexType == 35 || hex.hexType == 39 || hex.hexType == 43) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 35;
		}
		if (hex.hexType == 5 || hex.hexType == 10 || hex.hexType == 14 || hex.hexType == 18 || hex.hexType == 22 || hex.hexType == 26 || hex.hexType == 30 ||  hex.hexType == 34 || hex.hexType == 38 || hex.hexType == 42) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 34;
		}
		if (hex.hexType == 6 || hex.hexType == 12 || hex.hexType == 16 || hex.hexType == 20 || hex.hexType == 24 || hex.hexType == 28 || hex.hexType == 32 ||  hex.hexType == 36 || hex.hexType == 40 || hex.hexType == 44) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 36;
		}
	}

	public void BuildSensor (Hex hex) {		
		if (hex.hexType == 0 || hex.hexType == 9 || hex.hexType == 13 || hex.hexType == 17 || hex.hexType == 21 || hex.hexType == 25 || hex.hexType == 29 ||  hex.hexType == 33 || hex.hexType == 37 || hex.hexType == 41) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 37;
		}
		if (hex.hexType == 1 || hex.hexType == 11 || hex.hexType == 15 || hex.hexType == 19 || hex.hexType == 23 || hex.hexType == 27 || hex.hexType == 31 || hex.hexType == 35 || hex.hexType == 39 || hex.hexType == 43) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 39;
		}
		if (hex.hexType == 5 || hex.hexType == 10 || hex.hexType == 14 || hex.hexType == 18 || hex.hexType == 22 || hex.hexType == 26 || hex.hexType == 30 ||  hex.hexType == 34 || hex.hexType == 38 || hex.hexType == 42) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 38;
		}
		if (hex.hexType == 6 || hex.hexType == 12 || hex.hexType == 16 || hex.hexType == 20 || hex.hexType == 24 || hex.hexType == 28 || hex.hexType == 32 ||  hex.hexType == 36 || hex.hexType == 40 || hex.hexType == 44) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 40;
		}
	}
}
