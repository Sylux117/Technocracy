using UnityEngine;
using System.Collections;

public class Constructor : MonoBehaviour {

	public Hex hex;
	public Map map;

	void Start () {
		map = GameObject.Find ("Generated_map").GetComponent <Map> ();
	}

	public void BuildSensor (Hex hex) {
		if 
		Hex newHex = map.BuildingHex (6, hex);
		newHex.building = 5;
	}
	public void BuildEnergy (Hex hex) {		
		Hex newHex = map.BuildingHex (6, hex);
		newHex.building = 7;
	}
	public void BuildFactory (Hex hex) {		
		Hex newHex = map.BuildingHex (6, hex);
		newHex.building = 8;
	}
}
