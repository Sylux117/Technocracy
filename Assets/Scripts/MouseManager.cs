using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour {

	public Unit selectedUnit;
	public Map map;
	public Hex oldHex;

	public bool buildingBiology;
	public bool buildingEnergy;
	public bool buildingEngineering;
	public bool buildingFactory;
	public bool buildingPhysics;
	public bool buildingSensor;

	public bool canBuild;

	public bool isInBuildingRange;


	// Use this for initialization
	void Start () {
		map = GameObject.Find ("Generated_map").GetComponent <Map> ();
		canBuild = true;
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

			if (buildingBiology == true && Input.GetMouseButtonDown(1) && canBuild == true) {
				if (Vector3.Distance (hitObject.transform.parent.transform.position, new Vector3 (34.125f, 0f, 16.5f)) <= 5.26) {
					this.gameObject.GetComponent <Constructor> ().BuildBiology(hitObject.GetComponentInParent <Hex> ());
					buildingBiology = false;
					canBuild = false;
				}
			}

			if (buildingEnergy == true && Input.GetMouseButtonDown(1) && canBuild == true) {
				if (Mathf.Abs (hitObject.GetComponentInParent <Hex> ().x - 19) + Mathf.Abs (hitObject.GetComponentInParent <Hex> ().y - 11) == 3) {
					this.gameObject.GetComponent <Constructor> ().BuildEnergy (hitObject.GetComponentInParent <Hex> ());
					buildingEnergy = false;
					canBuild = false;
				}
			}

			if (buildingEngineering == true && Input.GetMouseButtonDown(1) && canBuild == true) {
				if (Mathf.Abs (hitObject.GetComponentInParent <Hex> ().x - 19) + Mathf.Abs (hitObject.GetComponentInParent <Hex> ().y - 11) == 3) {
					this.gameObject.GetComponent <Constructor> ().BuildEngineering (hitObject.GetComponentInParent <Hex> ());
					buildingEngineering = false;
					canBuild = false;
				}
			}

			if (buildingFactory == true && Input.GetMouseButtonDown(1) && canBuild == true) {
				if (Mathf.Abs (hitObject.GetComponentInParent <Hex> ().x - 19) + Mathf.Abs (hitObject.GetComponentInParent <Hex> ().y - 11) == 3) {
					this.gameObject.GetComponent <Constructor> ().BuildFactory (hitObject.GetComponentInParent <Hex> ());
					buildingFactory = false;
					canBuild = false;
				}
			}

			if (buildingPhysics == true && Input.GetMouseButtonDown(1) && canBuild == true) {
				if (Mathf.Abs (hitObject.GetComponentInParent <Hex> ().x - 19) + Mathf.Abs (hitObject.GetComponentInParent <Hex> ().y - 11) == 3) {
					this.gameObject.GetComponent <Constructor> ().BuildPhysics (hitObject.GetComponentInParent <Hex> ());
					buildingPhysics = false;
					canBuild = false;
				}
			}

			if (buildingSensor == true && Input.GetMouseButtonDown(1) && canBuild == true) {
				if (Mathf.Abs (hitObject.GetComponentInParent <Hex> ().x - 19) + Mathf.Abs (hitObject.GetComponentInParent <Hex> ().y - 11) == 3) {
					this.gameObject.GetComponent <Constructor> ().BuildSensor (hitObject.GetComponentInParent <Hex> ());
					buildingSensor = false;
					canBuild = false;
				}
			}

			if (hitObject == null) {
				oldHex.isSelected = false;
				selectedUnit = null;
				oldHex = null;
			}

		}
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

	#region Building

	public void BuildingBiology () {
		buildingBiology = true;
		buildingEnergy = false;
		buildingEngineering = false;
		buildingFactory = false;
		buildingPhysics = false;
		buildingSensor = false;
	}

	public void BuildingEnergy () {
		buildingBiology = false;
		buildingEnergy = true;
		buildingEngineering = false;
		buildingFactory = false;
		buildingPhysics = false;
		buildingSensor = false;
	}

	public void BuildingEngineering () {
		buildingBiology = false;
		buildingEnergy = false;
		buildingEngineering = true;
		buildingFactory = false;
		buildingPhysics = false;
		buildingSensor = false;
	}

	public void BuildingFactory () {
		buildingBiology = false;
		buildingEnergy = false;
		buildingEngineering = false;
		buildingFactory = true;
		buildingPhysics = false;
		buildingSensor = false;
  	}

	public void BuildingPhysics () {
		buildingBiology = false;
		buildingEnergy = false;
		buildingEngineering = false;
		buildingFactory = false;
		buildingPhysics = true;
		buildingSensor = false;	}

	public void BuildingSensor () {
		buildingBiology = false;
		buildingEnergy = false;
		buildingEngineering = false;
		buildingFactory = false;
		buildingPhysics = false;
		buildingSensor = true;
	}

	#endregion
}
