using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour {

	public Unit selectedUnit;
	public Map map;
	public Hex oldHex;
	public bool buildingSensor;
	public bool buildingEnergy;
	public bool buildingFactory;


	// Use this for initialization
	void Start () {
		map = GameObject.Find ("Generated_map").GetComponent <Map> ();
	}
	
	// Update is called once per frame
	void Update () {

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit)) {
			GameObject hitObject = hit.collider.transform.parent.gameObject;

			if (hitObject.GetComponent <Hex> () != null) {
				MouseOver_Hex (hitObject);
			} else if (hitObject.GetComponent <Unit> () != null){
				MouseOver_Unit (hitObject);
			}

			if (buildingSensor == true && Input.GetMouseButtonDown(1)) {
				this.gameObject.GetComponent <Constructor> ().BuildSensor(hitObject.GetComponentInParent <Hex> ());
				buildingSensor = false;
			}
			if (buildingEnergy == true && Input.GetMouseButtonDown(1)) {
				this.gameObject.GetComponent <Constructor> ().BuildEnergy(hitObject.GetComponentInParent <Hex> ());
				buildingEnergy = false;
			}
			if (buildingFactory == true && Input.GetMouseButtonDown(1)) {
				this.gameObject.GetComponent <Constructor> ().BuildFactory(hitObject.GetComponentInParent <Hex> ());
				buildingFactory = false;
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

	public void BuildingSensor () {
		buildingSensor = true;
	}

	public void BuildingEnergy () {
		buildingEnergy = true;
	}

	public void BuildingFactory () {
		buildingFactory = true;
	}
}
