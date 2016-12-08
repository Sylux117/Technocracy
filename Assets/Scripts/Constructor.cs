using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Constructor : MonoBehaviour {

	#region Variables
	public Hex hex;
	public Map map;
	public GameObject city;

	public GameObject scout;
	public GameObject securityForces;
	public GameObject scientistExpedition;
	public int turnCount;
	public bool scoutCount;
	public bool SFCount;
	public bool SECount;

	public bool isTraining;
	public bool beginCount = false;
	public int buildingProduction;
	public int Cost;

	private GameObject slider;
	public GameObject sliderPrefab;
	private int sliderCount = 1;
	#endregion

	void Start () {
		map = GameObject.Find ("Generated_map").GetComponent <Map> ();
		city = GameObject.FindGameObjectWithTag ("City").gameObject;
	}

	void Update () {

		if (isTraining == true && beginCount == false) {
			buildingProduction = 0;
			beginCount = true;
		}

		if (beginCount == true) {
			if (sliderCount < 2) {
				slider = Instantiate (sliderPrefab, city.transform.position, city.transform.rotation) as GameObject;
				sliderCount++;
				slider.gameObject.transform.SetParent (GameObject.Find ("Canvas").gameObject.transform);
			}
			if (slider != null) {
				slider.transform.position = Camera.main.WorldToScreenPoint (city.transform.position + new Vector3 (0.0f, 0.3f, 1f));				
				slider.GetComponent <Slider> ().value = buildingProduction;
				slider.GetComponent <Slider> ().maxValue = Cost;
			}
			if (buildingProduction >= Cost) {				
				Destroy (slider);
			}
		}

		if (scoutCount == true && beginCount == true && buildingProduction >= Cost) {
			TrainScout ();
			this.gameObject.GetComponent <MouseManager> ().canBuild = true;
			scoutCount = false;
			beginCount = false;
			isTraining = false;
		}

		if (SFCount == true && beginCount == true && buildingProduction >= Cost) {
			TrainSF ();
			this.gameObject.GetComponent <MouseManager> ().canBuild = true;
			SFCount = false;
			beginCount = false;
			isTraining = false;
		}

		if (SECount == true && beginCount == true && buildingProduction >= Cost) {
			TrainSE ();
			this.gameObject.GetComponent <MouseManager> ().canBuild = true;
			SECount = false;
			beginCount = false;
			isTraining = false;
		}
	}

	#region Building
	public void BuildBiology (Hex hex) {
		if (hex.hexType == 0 || hex.hexType == 9 || hex.hexType == 13 || hex.hexType == 17 || hex.hexType == 21 || hex.hexType == 25 || hex.hexType == 29 ||  hex.hexType == 33 || hex.hexType == 37 || hex.hexType == 41) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 9;
			newHex.isBuilding = true;
			newHex.Cost = 50;
		}
		if (hex.hexType == 1 || hex.hexType == 11 || hex.hexType == 15 || hex.hexType == 19 || hex.hexType == 23 || hex.hexType == 27 || hex.hexType == 31 || hex.hexType == 35 || hex.hexType == 39 || hex.hexType == 43) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 11;
			newHex.isBuilding = true;
			newHex.Cost = 50;
		}
		if (hex.hexType == 5 || hex.hexType == 10 || hex.hexType == 14 || hex.hexType == 18 || hex.hexType == 22 || hex.hexType == 26 || hex.hexType == 30 ||  hex.hexType == 34 || hex.hexType == 38 || hex.hexType == 42) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 10;
			newHex.isBuilding = true;
			newHex.Cost = 50;
		}
		if (hex.hexType == 6 || hex.hexType == 12 || hex.hexType == 16 || hex.hexType == 20 || hex.hexType == 24 || hex.hexType == 28 || hex.hexType == 32 ||  hex.hexType == 36 || hex.hexType == 40 || hex.hexType == 44) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 12;
			newHex.isBuilding = true;
			newHex.Cost = 50;
		}

	}

	public void BuildEnergy (Hex hex) {		
		if (hex.hexType == 0 || hex.hexType == 9 || hex.hexType == 13 || hex.hexType == 17 || hex.hexType == 21 || hex.hexType == 25 || hex.hexType == 29 ||  hex.hexType == 33 || hex.hexType == 37 || hex.hexType == 41) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 13;
			newHex.isBuilding = true;
			newHex.Cost = 100;
		}
		if (hex.hexType == 1 || hex.hexType == 11 || hex.hexType == 15 || hex.hexType == 19 || hex.hexType == 23 || hex.hexType == 27 || hex.hexType == 31 || hex.hexType == 35 || hex.hexType == 39 || hex.hexType == 43) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 15;
			newHex.isBuilding = true;
			newHex.Cost = 100;
		}
		if (hex.hexType == 5 || hex.hexType == 10 || hex.hexType == 14 || hex.hexType == 18 || hex.hexType == 22 || hex.hexType == 26 || hex.hexType == 30 ||  hex.hexType == 34 || hex.hexType == 38 || hex.hexType == 42) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 14;
			newHex.isBuilding = true;
			newHex.Cost = 100;
		}
		if (hex.hexType == 6 || hex.hexType == 12 || hex.hexType == 16 || hex.hexType == 20 || hex.hexType == 24 || hex.hexType == 28 || hex.hexType == 32 ||  hex.hexType == 36 || hex.hexType == 40 || hex.hexType == 44) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 16;
			newHex.isBuilding = true;
			newHex.Cost = 100;
		}
	}

	public void BuildEngineering (Hex hex) {		
		if (hex.hexType == 0 || hex.hexType == 9 || hex.hexType == 13 || hex.hexType == 17 || hex.hexType == 21 || hex.hexType == 25 || hex.hexType == 29 ||  hex.hexType == 33 || hex.hexType == 37 || hex.hexType == 41) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 17;
			newHex.isBuilding = true;
			newHex.Cost = 50;
		}
		if (hex.hexType == 1 || hex.hexType == 11 || hex.hexType == 15 || hex.hexType == 19 || hex.hexType == 23 || hex.hexType == 27 || hex.hexType == 31 || hex.hexType == 35 || hex.hexType == 39 || hex.hexType == 43) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 19;
			newHex.isBuilding = true;
			newHex.Cost = 50;
		}
		if (hex.hexType == 5 || hex.hexType == 10 || hex.hexType == 14 || hex.hexType == 18 || hex.hexType == 22 || hex.hexType == 26 || hex.hexType == 30 ||  hex.hexType == 34 || hex.hexType == 38 || hex.hexType == 42) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 18;
			newHex.isBuilding = true;
			newHex.Cost = 50;
		}
		if (hex.hexType == 6 || hex.hexType == 12 || hex.hexType == 16 || hex.hexType == 20 || hex.hexType == 24 || hex.hexType == 28 || hex.hexType == 32 ||  hex.hexType == 36 || hex.hexType == 40 || hex.hexType == 44) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 20;
			newHex.isBuilding = true;
			newHex.Cost = 50;
		}
	}

	public void BuildFactory (Hex hex) {		
		if (hex.hexType == 0 || hex.hexType == 9 || hex.hexType == 13 || hex.hexType == 17 || hex.hexType == 21 || hex.hexType == 25 || hex.hexType == 29 ||  hex.hexType == 33 || hex.hexType == 37 || hex.hexType == 41) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 21;
			newHex.isBuilding = true;
			newHex.Cost = 100;
		}
		if (hex.hexType == 1 || hex.hexType == 11 || hex.hexType == 15 || hex.hexType == 19 || hex.hexType == 23 || hex.hexType == 27 || hex.hexType == 31 || hex.hexType == 35 || hex.hexType == 39 || hex.hexType == 43) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 23;
			newHex.isBuilding = true;
			newHex.Cost = 100;
		}
		if (hex.hexType == 5 || hex.hexType == 10 || hex.hexType == 14 || hex.hexType == 18 || hex.hexType == 22 || hex.hexType == 26 || hex.hexType == 30 ||  hex.hexType == 34 || hex.hexType == 38 || hex.hexType == 42) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 22;
			newHex.isBuilding = true;
			newHex.Cost = 100;
		}
		if (hex.hexType == 6 || hex.hexType == 12 || hex.hexType == 16 || hex.hexType == 20 || hex.hexType == 24 || hex.hexType == 28 || hex.hexType == 32 ||  hex.hexType == 36 || hex.hexType == 40 || hex.hexType == 44) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 24;
			newHex.isBuilding = true;
			newHex.Cost = 100;
		}
	}

	public void BuildFarm (Hex hex) {		
		if (hex.hexType == 0 || hex.hexType == 9 || hex.hexType == 13 || hex.hexType == 17 || hex.hexType == 21 || hex.hexType == 25 || hex.hexType == 29 ||  hex.hexType == 33 || hex.hexType == 37 || hex.hexType == 41) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 45;
			newHex.isBuilding = true;
			newHex.Cost = 100;
		}
		if (hex.hexType == 1 || hex.hexType == 11 || hex.hexType == 15 || hex.hexType == 19 || hex.hexType == 23 || hex.hexType == 27 || hex.hexType == 31 || hex.hexType == 35 || hex.hexType == 39 || hex.hexType == 43) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 47;
			newHex.isBuilding = true;
			newHex.Cost = 100;
		}
		if (hex.hexType == 5 || hex.hexType == 10 || hex.hexType == 14 || hex.hexType == 18 || hex.hexType == 22 || hex.hexType == 26 || hex.hexType == 30 ||  hex.hexType == 34 || hex.hexType == 38 || hex.hexType == 42) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 46;
			newHex.isBuilding = true;
			newHex.Cost = 100;
		}
		if (hex.hexType == 6 || hex.hexType == 12 || hex.hexType == 16 || hex.hexType == 20 || hex.hexType == 24 || hex.hexType == 28 || hex.hexType == 32 ||  hex.hexType == 36 || hex.hexType == 40 || hex.hexType == 44) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 48;
			newHex.isBuilding = true;
			newHex.Cost = 100;
		}
	}

	public void BuildPhysics (Hex hex) {		
		if (hex.hexType == 0 || hex.hexType == 9 || hex.hexType == 13 || hex.hexType == 17 || hex.hexType == 21 || hex.hexType == 25 || hex.hexType == 29 ||  hex.hexType == 33 || hex.hexType == 37 || hex.hexType == 41) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 33;
			newHex.isBuilding = true;
			newHex.Cost = 50;
		}
		if (hex.hexType == 1 || hex.hexType == 11 || hex.hexType == 15 || hex.hexType == 19 || hex.hexType == 23 || hex.hexType == 27 || hex.hexType == 31 || hex.hexType == 35 || hex.hexType == 39 || hex.hexType == 43) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 35;
			newHex.isBuilding = true;
			newHex.Cost = 50;
		}
		if (hex.hexType == 5 || hex.hexType == 10 || hex.hexType == 14 || hex.hexType == 18 || hex.hexType == 22 || hex.hexType == 26 || hex.hexType == 30 ||  hex.hexType == 34 || hex.hexType == 38 || hex.hexType == 42) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 34;
			newHex.isBuilding = true;
			newHex.Cost = 50;
		}
		if (hex.hexType == 6 || hex.hexType == 12 || hex.hexType == 16 || hex.hexType == 20 || hex.hexType == 24 || hex.hexType == 28 || hex.hexType == 32 ||  hex.hexType == 36 || hex.hexType == 40 || hex.hexType == 44) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 36;
			newHex.isBuilding = true;
			newHex.Cost = 50;
		}
	}

	public void BuildSensor (Hex hex) {		
		if (hex.hexType == 0 || hex.hexType == 9 || hex.hexType == 13 || hex.hexType == 17 || hex.hexType == 21 || hex.hexType == 25 || hex.hexType == 29 ||  hex.hexType == 33 || hex.hexType == 37 || hex.hexType == 41) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 37;
			newHex.isBuilding = true;
			newHex.Cost = 100;
		}
		if (hex.hexType == 1 || hex.hexType == 11 || hex.hexType == 15 || hex.hexType == 19 || hex.hexType == 23 || hex.hexType == 27 || hex.hexType == 31 || hex.hexType == 35 || hex.hexType == 39 || hex.hexType == 43) {
			Hex newHex = map.BuildingHex (7, hex);
			newHex.building = 39;
			newHex.isBuilding = true;
			newHex.Cost = 100;
		}
		if (hex.hexType == 5 || hex.hexType == 10 || hex.hexType == 14 || hex.hexType == 18 || hex.hexType == 22 || hex.hexType == 26 || hex.hexType == 30 ||  hex.hexType == 34 || hex.hexType == 38 || hex.hexType == 42) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 38;
			newHex.isBuilding = true;
			newHex.Cost = 100;
		}
		if (hex.hexType == 6 || hex.hexType == 12 || hex.hexType == 16 || hex.hexType == 20 || hex.hexType == 24 || hex.hexType == 28 || hex.hexType == 32 ||  hex.hexType == 36 || hex.hexType == 40 || hex.hexType == 44) {
			Hex newHex = map.BuildingHex (8, hex);
			newHex.building = 40;
			newHex.isBuilding = true;
			newHex.Cost = 100;
		}
	}

	public void TrainScout () {		
		GameObject newScout = Instantiate (scout, city.transform.position, city.transform.rotation) as GameObject;
		newScout.GetComponent <Unit> ().x = city.GetComponent <Hex> ().x;
		newScout.GetComponent <Unit> ().y = city.GetComponent <Hex> ().y;

	}

	public void TrainSF () {
		GameObject newSecurityForces = Instantiate (securityForces, city.transform.position, city.transform.rotation) as GameObject;
		newSecurityForces.GetComponent <Unit> ().x = city.GetComponent <Hex> ().x;
		newSecurityForces.GetComponent <Unit> ().y = city.GetComponent <Hex> ().y;
	}

	public void TrainSE () {
		GameObject newScientist = Instantiate (scientistExpedition, city.transform.position, city.transform.rotation) as GameObject;
		newScientist.GetComponent <Unit> ().x = city.GetComponent <Hex> ().x;
		newScientist.GetComponent <Unit> ().y = city.GetComponent <Hex> ().y;
	}
	#endregion

}
