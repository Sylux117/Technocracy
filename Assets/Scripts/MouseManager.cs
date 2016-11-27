using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour {

	public Unit selectedUnit;
	public Map map;
	public Hex oldHex;
	public CityManagement city;

	public bool building;

	public bool buildingBiology;
	public bool buildingEnergy;
	public bool buildingEngineering;
	public bool buildingFactory;
	public bool buildingFarm;
	public bool buildingPhysics;
	public bool buildingSensor;
	public bool trainingScout;
	public bool trainingSF;
	public bool trainingSE;

	public bool canBuild;

	public bool isInBuildingRange;

	public GameObject slider;

	public Text text;

	public Image image;


	// Use this for initialization
	void Start () {
		map = GameObject.Find ("Generated_map").GetComponent <Map> ();
		canBuild = true;
		city = GameObject.FindGameObjectWithTag ("City").GetComponent <CityManagement> ();
	}
	
	// Update is called once per frame
	void Update () {

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;


		if (Physics.Raycast(ray, out hit) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject (-1)) {
			GameObject hitObject = hit.collider.transform.parent.gameObject;

			if (hitObject.GetComponent <Hex> () != null) {
				MouseOver_Hex (hitObject);
			} else if (hitObject.GetComponent <Unit> () != null){
				MouseOver_Unit (hitObject);
			}

			if (buildingBiology == true && Input.GetMouseButtonDown(1) && canBuild == true && InRange(hitObject)) {				
				this.gameObject.GetComponent <Constructor> ().BuildBiology(hitObject.GetComponentInParent <Hex> ());
				buildingBiology = false;
				canBuild = false;
			}

			if (buildingEnergy == true && Input.GetMouseButtonDown(1) && canBuild == true && InRange(hitObject)) {
				this.gameObject.GetComponent <Constructor> ().BuildEnergy (hitObject.GetComponentInParent <Hex> ());
				buildingEnergy = false;
				canBuild = false;			
			}

			if (buildingEngineering == true && Input.GetMouseButtonDown(1) && canBuild == true && InRange(hitObject)) {				
				this.gameObject.GetComponent <Constructor> ().BuildEngineering (hitObject.GetComponentInParent <Hex> ());
				buildingEngineering = false;
				canBuild = false;
			}

			if (buildingFactory == true && Input.GetMouseButtonDown(1) && canBuild == true && InRange(hitObject)) {			
				this.gameObject.GetComponent <Constructor> ().BuildFactory (hitObject.GetComponentInParent <Hex> ());
				buildingFactory = false;
				canBuild = false;
			}

			if (buildingFarm == true && Input.GetMouseButtonDown(1) && canBuild == true && InRange(hitObject)) {			
				this.gameObject.GetComponent <Constructor> ().BuildFarm (hitObject.GetComponentInParent <Hex> ());
				buildingFarm = false;
				canBuild = false;
			}

			if (buildingPhysics == true && Input.GetMouseButtonDown(1) && canBuild == true && InRange(hitObject)) {
				this.gameObject.GetComponent <Constructor> ().BuildPhysics (hitObject.GetComponentInParent <Hex> ());
				buildingPhysics = false;
				canBuild = false;
			}

			if (buildingSensor == true && Input.GetMouseButtonDown(1) && canBuild == true && InRange(hitObject)) {
				this.gameObject.GetComponent <Constructor> ().BuildSensor (hitObject.GetComponentInParent <Hex> ());
				buildingSensor = false;
				canBuild = false;
			}

			if (trainingScout == true && canBuild == true) {
				this.gameObject.GetComponent <Constructor> ().turnCount = 0;
				this.gameObject.GetComponent <Constructor> ().scoutCount = true;
				this.gameObject.GetComponent <Constructor> ().isTraining = true;
				this.gameObject.GetComponent <Constructor> ().Cost = 50;
				trainingScout = false;
				canBuild = false;
			}

			if (trainingSF == true && canBuild == true) {
				this.gameObject.GetComponent <Constructor> ().turnCount = 0;
				this.gameObject.GetComponent <Constructor> ().SFCount = true;
				this.gameObject.GetComponent <Constructor> ().isTraining = true;
				this.gameObject.GetComponent <Constructor> ().Cost = 75;
				trainingSF = false;
				canBuild = false;
			}

			if (trainingSE == true && canBuild == true) {
				this.gameObject.GetComponent <Constructor> ().turnCount = 0;
				this.gameObject.GetComponent <Constructor> ().SECount = true;
				this.gameObject.GetComponent <Constructor> ().isTraining = true;
				this.gameObject.GetComponent <Constructor> ().Cost = 100;
				trainingSE = false;
				canBuild = false;
			}


			if (hitObject == null) {
				oldHex.isSelected = false;
				selectedUnit = null;
				oldHex = null;
			}

		}

		slider.transform.position = Camera.main.WorldToScreenPoint (city.gameObject.transform.position + new Vector3 (0.05f, 1f, 1f));
		text.transform.position = Camera.main.WorldToScreenPoint (city.gameObject.transform.position + new Vector3 (-1.5f, 1f, 1f));
		image.transform.position = Camera.main.WorldToScreenPoint (city.gameObject.transform.position + new Vector3 (-1.5f, 1f, 1f));
	}

	void MouseOver_Hex(GameObject hitObject) {
		
		if (Input.GetMouseButtonDown(0) && hitObject.GetComponentInParent <Hex> () != null && oldHex == null) {
			hitObject.GetComponentInParent <Hex> ().isSelected = true;
			oldHex = hitObject.GetComponentInParent <Hex> ();
			if (hitObject.GetComponentInParent <CityManagement> () != null) {
				
			}
		} else if (Input.GetMouseButtonDown(0) && hitObject.GetComponentInParent <Hex> () != null && oldHex != null) {
			if (hitObject.GetComponentInParent <Hex> () == oldHex) {
				oldHex.isSelected = false;
				oldHex = null;
			} else if (hitObject.GetComponentInParent <Hex> () != oldHex) {
				oldHex.isSelected = false;
				hitObject.GetComponentInParent <Hex> ().isSelected = true;
				oldHex = hitObject.GetComponentInParent <Hex> ();
			}
		}

		if (selectedUnit != null && Input.GetMouseButtonDown(1) && hitObject.GetComponent <Unit> () == null) {

			map.selectedUnit = selectedUnit.gameObject;
			map.GeneratePathTo ((hitObject.GetComponent <Hex> ().x), (hitObject.GetComponent <Hex> ().y), selectedUnit.x, selectedUnit.y);

		} else if (selectedUnit != null && hitObject.GetComponent <Unit>() == null && Input.GetMouseButtonDown(0)) {
			selectedUnit.isSelected = false;
			selectedUnit = null;
		}
	}

	void MouseOver_Unit(GameObject hitObject) {
		if (Input.GetMouseButtonDown(0)) {
			selectedUnit = hitObject.GetComponent <Unit> ();
			selectedUnit.isSelected = true;
			if (oldHex != null) {
				oldHex.isSelected = false;
				oldHex = null;
			}
		}
  	}

	public bool InRange (GameObject hitObject) {
		int dist = map.HexDistance (city.gameObject.GetComponent <Hex> ().x, city.gameObject.GetComponent <Hex> ().y, hitObject.GetComponentInParent <Hex> ().x, hitObject.GetComponentInParent <Hex> ().y);
		if (city.cityLevel == 1) {
			if (dist > 1)
				return false;
			else
				return true;			
		} else if (city.cityLevel == 2) {
			if (dist > 2)
				return false;
			else
				return true;
		} else if (city.cityLevel == 3) {
			if (dist > 3)
				return false;
			else
				return true;
		} else {
			return true;
		}
	}

	#region Building

	public void Buildings () {
		GameObject.FindGameObjectWithTag("City").GetComponent <CityManagement> ().ChangeCanvas(1);
	}

	public void Units () {
		GameObject.FindGameObjectWithTag("City").GetComponent <CityManagement> ().ChangeCanvas(2);
	}

	public void BuildingBiology () {
		buildingBiology = true;
		buildingEnergy = false;
		buildingEngineering = false;
		buildingFactory = false;
		buildingFarm = false;
		buildingPhysics = false;
		buildingSensor = false;
		trainingScout = false;
		trainingSF = false;
		trainingSE = false;
	}

	public void BuildingEnergy () {
		buildingBiology = false;
		buildingEnergy = true;
		buildingEngineering = false;
		buildingFactory = false;
		buildingFarm = false;
		buildingPhysics = false;
		buildingSensor = false;
		trainingScout = false;
		trainingSF = false;
		trainingSE = false;
	}

	public void BuildingEngineering () {
		buildingBiology = false;
		buildingEnergy = false;
		buildingEngineering = true;
		buildingFactory = false;
		buildingFarm = false;
		buildingPhysics = false;
		buildingSensor = false;
		trainingScout = false;
		trainingSF = false;
		trainingSE = false;
	}

	public void BuildingFactory () {
		buildingBiology = false;
		buildingEnergy = false;
		buildingEngineering = false;
		buildingFactory = true;
		buildingFarm = false;
		buildingPhysics = false;
		buildingSensor = false;
		trainingScout = false;
		trainingSF = false;
		trainingSE = false;
  	}

	public void BuildingFarm () {
		buildingBiology = false;
		buildingEnergy = false;
		buildingEngineering = false;
		buildingFactory = false;
		buildingFarm = true;
		buildingPhysics = false;
		buildingSensor = false;
		trainingScout = false;
		trainingSF = false;
		trainingSE = false;
	}

	public void BuildingPhysics () {
		buildingBiology = false;
		buildingEnergy = false;
		buildingEngineering = false;
		buildingFactory = false;
		buildingFarm = false;
		buildingPhysics = true;
		buildingSensor = false;
		trainingScout = false;
		trainingSF = false;
		trainingSE = false;
	}

	public void BuildingSensor () {
		buildingBiology = false;
		buildingEnergy = false;
		buildingEngineering = false;
		buildingFactory = false;
		buildingFarm = false;
		buildingPhysics = false;
		buildingSensor = true;
		trainingScout = false;
		trainingSF = false;
		trainingSE = false;
	}

	public void TrainingScout () {
		buildingBiology = false;
		buildingEnergy = false;
		buildingEngineering = false;
		buildingFactory = false;
		buildingFarm = false;
		buildingPhysics = false;
		buildingSensor = false;
		trainingScout = true;
		trainingSF = false;
		trainingSE = false;
	}

	public void TrainingSF () {
		buildingBiology = false;
		buildingEnergy = false;
		buildingEngineering = false;
		buildingFactory = false;
		buildingFarm = false;
		buildingPhysics = false;
		buildingSensor = false;
		trainingScout = false;
		trainingSF = true;
		trainingSE = false;
	}

	public void TrainingSE () {
		buildingBiology = false;
		buildingEnergy = false;
		buildingEngineering = false;
		buildingFactory = false;
		buildingFarm = false;
		buildingPhysics = false;
		buildingSensor = false;
		trainingScout = false;
		trainingSF = false;
		trainingSE = true;
	}

	#endregion
}
