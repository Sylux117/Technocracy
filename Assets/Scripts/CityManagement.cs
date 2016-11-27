using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CityManagement : MonoBehaviour {

	public GameObject canvas;
	public GameObject buildingCanvas;
	public GameObject unitCanvas;
	public Hex hex;
	public int range = 3;

	public int cityLevel;
	public float food;
	public float production;
	public float biology;
	public float physics;
	public float engineering;

	public bool active;
	public int activeCanvas;


	void Start () {
		canvas = GameObject.Find("CityCanvas").gameObject;
		canvas.SetActive (false);
		buildingCanvas = GameObject.Find ("CityCanvasBuildings").gameObject;
		buildingCanvas.SetActive (false);
		unitCanvas = GameObject.Find ("CityCanvasUnits").gameObject;
		unitCanvas.SetActive (false);
		hex = this.gameObject.GetComponent <Hex> ();
		cityLevel = 1;
	}

	void Update () {
		if (hex.isSelected == true) {
			active = true;
			canvas.SetActive (true);
		} else {
			active = false;
			canvas.SetActive (false);
			buildingCanvas.SetActive (false);
			unitCanvas.SetActive (false);
		}

		if (food >= 200) {
			cityLevel = 2;
		}
		if (food >= 800) {
			cityLevel = 3;
		}
		if (food >= 1800) {
			cityLevel = 4;
		}
		if (food >= 3800) {
			cityLevel = 5;
		}
		if (food >= 7800) {
			cityLevel = 6;
		}
	}

	public void CityLeveler (float foodPerTurn, float productionPerTurn, float biologyPerTurn, float physicsPerTurn, float engineeringPerTurn) {
		if (food + foodPerTurn >= 200) {
			GameObject.Find ("MouseManager").GetComponent <MouseManager> ().slider.GetComponent <Slider> ().maxValue = 800;
		}
		if (food + foodPerTurn >= 800) {
			GameObject.Find ("MouseManager").GetComponent <MouseManager> ().slider.GetComponent <Slider> ().maxValue = 1800;
		}
		if (food + foodPerTurn >= 1800) {
			GameObject.Find ("MouseManager").GetComponent <MouseManager> ().slider.GetComponent <Slider> ().maxValue = 3800;
		}
		if (food + foodPerTurn >= 3800) {
			GameObject.Find ("MouseManager").GetComponent <MouseManager> ().slider.GetComponent <Slider> ().maxValue = 7800;
		}
		food += foodPerTurn;
		production += productionPerTurn;
		biology += biologyPerTurn;
		physics += physicsPerTurn;
		engineering += engineeringPerTurn;

	}

	public void ChangeCanvas (int canvasType) {

		if (active == true && canvasType == 0) {
			canvas.SetActive (true);
			buildingCanvas.SetActive (false);
			unitCanvas.SetActive (false);
		}
		if (active == true && canvasType == 1) {
			canvas.SetActive (false);
			buildingCanvas.SetActive (true);
			unitCanvas.SetActive (false);
		}
		if (active == true && canvasType == 2) {
			canvas.SetActive (false);
			buildingCanvas.SetActive (false);
			unitCanvas.SetActive (true);
		}
	}
}
