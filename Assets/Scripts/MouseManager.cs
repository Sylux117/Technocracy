using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour {

	#region Variables
	public Unit selectedUnit;
	public Map map;
	public Hex oldHex;
	public CityManagement city;

	public bool building;
	public bool tech;

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

	public GameObject Target;
	#endregion

	void Start () {
		map = GameObject.Find ("Generated_map").GetComponent <Map> ();
		canBuild = true;
		city = GameObject.FindGameObjectWithTag ("City").GetComponent <CityManagement> ();
	}

	void Update () {

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject (-1)) {
			GameObject hitObject = hit.collider.transform.parent.gameObject;

			// Mouse Over Something
			if (hitObject.GetComponent <Hex> () != null) {
				MouseOver_Hex (hitObject);
			} else if (hitObject.GetComponent <Unit> () != null){
				MouseOver_Unit (hitObject);
			}

			//To build biology lab
			if (buildingBiology == true && Input.GetMouseButtonDown(1) && canBuild == true && InRange(hitObject)) {				
				this.gameObject.GetComponent <Constructor> ().BuildBiology(hitObject.GetComponentInParent <Hex> ());
				buildingBiology = false;
				canBuild = false;
			}

			//To build solar panel
			if (buildingEnergy == true && Input.GetMouseButtonDown(1) && canBuild == true && InRange(hitObject)) {
				this.gameObject.GetComponent <Constructor> ().BuildEnergy (hitObject.GetComponentInParent <Hex> ());
				buildingEnergy = false;
				canBuild = false;			
			}

			//To build engineering lab
			if (buildingEngineering == true && Input.GetMouseButtonDown(1) && canBuild == true && InRange(hitObject)) {				
				this.gameObject.GetComponent <Constructor> ().BuildEngineering (hitObject.GetComponentInParent <Hex> ());
				buildingEngineering = false;
				canBuild = false;
			}

			//To build factory
			if (buildingFactory == true && Input.GetMouseButtonDown(1) && canBuild == true && InRange(hitObject)) {			
				this.gameObject.GetComponent <Constructor> ().BuildFactory (hitObject.GetComponentInParent <Hex> ());
				buildingFactory = false;
				canBuild = false;
			}

			//To build farm
			if (buildingFarm == true && Input.GetMouseButtonDown(1) && canBuild == true && InRange(hitObject)) {			
				this.gameObject.GetComponent <Constructor> ().BuildFarm (hitObject.GetComponentInParent <Hex> ());
				buildingFarm = false;
				canBuild = false;
			}

			//To build physics lab
			if (buildingPhysics == true && Input.GetMouseButtonDown(1) && canBuild == true && InRange(hitObject)) {
				this.gameObject.GetComponent <Constructor> ().BuildPhysics (hitObject.GetComponentInParent <Hex> ());
				buildingPhysics = false;
				canBuild = false;
			}

			//To build sensor array
			if (buildingSensor == true && Input.GetMouseButtonDown(1) && canBuild == true && InRange(hitObject)) {
				this.gameObject.GetComponent <Constructor> ().BuildSensor (hitObject.GetComponentInParent <Hex> ());
				buildingSensor = false;
				canBuild = false;
			}

			//To train scout
			if (trainingScout == true && canBuild == true) {
				this.gameObject.GetComponent <Constructor> ().turnCount = 0;
				this.gameObject.GetComponent <Constructor> ().scoutCount = true;
				this.gameObject.GetComponent <Constructor> ().isTraining = true;
				this.gameObject.GetComponent <Constructor> ().Cost = 25;
				trainingScout = false;
				canBuild = false;
			}

			//To train security forces
			if (trainingSF == true && canBuild == true) {
				this.gameObject.GetComponent <Constructor> ().turnCount = 0;
				this.gameObject.GetComponent <Constructor> ().SFCount = true;
				this.gameObject.GetComponent <Constructor> ().isTraining = true;
				this.gameObject.GetComponent <Constructor> ().Cost = 50;
				trainingSF = false;
				canBuild = false;
			}

			//To train scientist expedition
			if (trainingSE == true && canBuild == true) {
				this.gameObject.GetComponent <Constructor> ().turnCount = 0;
				this.gameObject.GetComponent <Constructor> ().SECount = true;
				this.gameObject.GetComponent <Constructor> ().isTraining = true;
				this.gameObject.GetComponent <Constructor> ().Cost = 75;
				trainingSE = false;
				canBuild = false;
			}

			if (hitObject == null) {
				oldHex.isSelected = false;
				selectedUnit = null;
				oldHex = null;
			}

		}

		//Put the city level number as well as the slider in its position in the canvas
		slider.transform.position = Camera.main.WorldToScreenPoint (city.gameObject.transform.position + new Vector3 (0.05f, 1f, 1f));
		text.transform.position = Camera.main.WorldToScreenPoint (city.gameObject.transform.position + new Vector3 (-1.5f, 1f, 1f));
		image.transform.position = Camera.main.WorldToScreenPoint (city.gameObject.transform.position + new Vector3 (-1.5f, 1f, 1f));
	}

	#region Functions
	//Check if the mouse is over a hex
	void MouseOver_Hex(GameObject hitObject) {
		
		if (Input.GetMouseButtonDown(0) && hitObject.GetComponentInParent <Hex> () != null && oldHex == null) {
			hitObject.GetComponentInParent <Hex> ().isSelected = true;
			oldHex = hitObject.GetComponentInParent <Hex> ();
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
			GameObject target = Instantiate (Target, hitObject.transform.position, Quaternion.identity) as GameObject;
			map.selectedUnit = selectedUnit.gameObject;
			map.GeneratePathTo ((hitObject.GetComponent <Hex> ().x), (hitObject.GetComponent <Hex> ().y), selectedUnit.x, selectedUnit.y);
			selectedUnit.GetComponent <Unit> ().waiting = false;
		} else if (selectedUnit != null && hitObject.GetComponent <Unit>() == null && Input.GetMouseButtonDown(0)) {
			selectedUnit.isSelected = false;
			selectedUnit = null;
		}
	}

	//Check if mouse is over a unit
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

	//Check if a Hex is in range of the city
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
	#endregion

	#region Building

	public void Buildings () {
		GameObject.FindGameObjectWithTag ("City").GetComponent <CityManagement> ().ChangeCanvas (1);
	}

	public void Units () {
		GameObject.FindGameObjectWithTag ("City").GetComponent <CityManagement> ().ChangeCanvas (2);
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
