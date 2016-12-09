using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NextTurnManager : MonoBehaviour {

	#region Variables
	int turnCount;
	public GameObject[] units;
	public Text turnNumber;
	public List <GameObject> building;

	public float food = 0;
	public float production = 0;
	public float biology = 0;
	public float physics = 0;
	public float engineering = 0;

	public Text foodText;
	public Text productionText;
	public Text biologyText;
	public Text physicsText;
	public Text engineeringText;
	#endregion

	void Start () {
		turnCount = 0;
		units = null;
		building = new List <GameObject> ();
	}

	void Update () {
		units = GameObject.FindGameObjectsWithTag ("Unit");
		ShowResources ();
	}

	#region Functions
	public void NextTurn () {

		for (int i = 0; i < units.Length; i++) {
			if (units [i].GetComponent <Unit> ().currentPath == null) {
				if (units [i].GetComponent <Unit> ().waiting == false) {
					return;
				}
			}
		}

		if (this.gameObject.GetComponent <MouseManager> ().canBuild == true) {
			return;
		}

		if (GameObject.Find("TechTree").GetComponent <TechTree> ().canResearch == true) {
			return;
		}

		for (int i = 0; i < units.Length; i++) {
			units [i].GetComponent <Unit> ().MoveNextHex ();
		}

		this.gameObject.GetComponent <Constructor> ().turnCount++;


		Resources ();
		this.gameObject.GetComponent <MouseManager> ().slider.GetComponent <Slider> ().value = GameObject.FindGameObjectWithTag ("City").GetComponent <CityManagement> ().food;
		this.gameObject.GetComponent <MouseManager> ().text.text = (GameObject.FindGameObjectWithTag ("City").GetComponent <CityManagement> ().cityLevel.ToString ());
		ShowTurn ();
		turnCount++;


		for (int i = 0; i < building.Count; i++) {
			building [i].gameObject.GetComponent <Hex> ().buildingProduction += (int)production;
		}

		this.gameObject.GetComponent <Constructor> ().buildingProduction += (int)production;



	}

	public void ShowTurn () {
		turnNumber.text = "Turn " + turnCount;
	}

	public void AddBuilding (GameObject build) {
		building.Add (build.gameObject);
	}

	public void RemoveBuilding (GameObject build) {
		for (int i = 0; i < building.Count; i++) {
			if (building[i] == build){
				building.RemoveAt (i);
			}
		}
	}

	public void Resources () {
		GameObject city = GameObject.FindGameObjectWithTag ("City");
		int cityx = city.GetComponent <Hex> ().x;
		int cityy = city.GetComponent <Hex> ().y;
		food = city.GetComponent <Hex> ().food;
		production = city.GetComponent <Hex> ().production;

		food = 0;
		production = 0;
		biology = 0;
		physics = 0;
		engineering = 0;

		if (city.GetComponent <CityManagement> ().cityLevel == 1) {
			Hex target1 = GameObject.Find ("Hex_" + (cityx + 1) + "_" + cityy).GetComponent <Hex> ();
			Hex target2 = GameObject.Find ("Hex_" + (cityx - 1) + "_" + cityy).GetComponent <Hex> ();
				
			food += target1.food;
			food += target2.food;
			production += target1.production;
			production += target2.production;
			biology += target1.biology;
			biology += target2.biology;
			physics += target1.physics;
			physics += target2.physics;
			engineering += target1.engineering;
			engineering += target2.engineering;

			for (int i = 0; i < 2; i++) {
				Hex targeti1 = GameObject.Find ("Hex_" + (cityx + i) + "_" + (cityy + 1)).GetComponent <Hex> ();
				Hex targeti2 = GameObject.Find ("Hex_" + (cityx + i) + "_" + (cityy - 1)).GetComponent <Hex> ();
				food += targeti1.food;
				food += targeti2.food;
				production += targeti1.production;
				production += targeti2.production;
				biology += targeti1.biology;
				biology += targeti2.biology;
				physics += targeti1.physics;
				physics += targeti2.physics;
				engineering += targeti1.engineering;
				engineering += targeti2.engineering;
			}

			city.GetComponent <CityManagement> ().CityLeveler (food, production, biology, physics, engineering);
		}

		if (city.GetComponent <CityManagement> ().cityLevel == 2) {
			for (int x = 0; x < 2; x++) {
				Hex target1 = GameObject.Find ("Hex_" + (x + cityx + 1) + "_" + cityy).GetComponent <Hex> ();
				Hex target2 = GameObject.Find ("Hex_" + (cityx - 1 - x) + "_" + cityy).GetComponent <Hex> ();

				food += target1.food;
				food += target2.food;
				production += target1.production;
				production += target2.production;
				biology += target1.biology;
				biology += target2.biology;
				physics += target1.physics;
				physics += target2.physics;
				engineering += target1.engineering;
				engineering += target2.engineering;
			}
			for (int i = 1; i < 5; i++) {
				Hex target1 = GameObject.Find ("Hex_" + (cityx - 2 + i) + "_" + (cityy + 1)).GetComponent <Hex> ();
				Hex target2 = GameObject.Find ("Hex_" + (cityx - 2 + i) + "_" + (cityy - 1)).GetComponent <Hex> ();
				food += target1.food;
				food += target2.food;
				production += target1.production;
				production += target2.production;
				biology += target1.biology;
				biology += target2.biology;
				physics += target1.physics;
				physics += target2.physics;
				engineering += target1.engineering;
				engineering += target2.engineering;
			}
			for (int x = 0; x < 3; x++) {
				Hex target1 = GameObject.Find ("Hex_" + (x + cityx - 1) + "_" + (cityy + 2)).GetComponent <Hex> ();
				Hex target2 = GameObject.Find ("Hex_" + (x + cityx - 1) + "_" + (cityy - 2)).GetComponent <Hex> ();
				food += target1.food;
				production += target1.production;
				food += target2.food;
				production += target2.production;
				biology += target1.biology;
				biology += target2.biology;
				physics += target1.physics;
				physics += target2.physics;
				engineering += target1.engineering;
				engineering += target2.engineering;
			}
			city.GetComponent <CityManagement> ().CityLeveler (food, production, biology, physics, engineering);
		}

		if (city.GetComponent <CityManagement> ().cityLevel >= 3) {
			for (int x = 0; x < 3; x++) {
				Hex target1 = GameObject.Find ("Hex_" + (x + cityx + 1) + "_" + cityy).GetComponent <Hex> ();
				Hex target2 = GameObject.Find ("Hex_" + (cityx - 1 - x) + "_" + cityy).GetComponent <Hex> ();

				food += target1.food;
				food += target2.food;
				production += target1.production;
				production += target2.production;
				biology += target1.biology;
				biology += target2.biology;
				physics += target1.physics;
				physics += target2.physics;
				engineering += target1.engineering;
				engineering += target2.engineering;
			}
			for (int i = 0; i < 6; i++) {
				Hex target1 = GameObject.Find ("Hex_" + (cityx - 2 + i) + "_" + (cityy + 1)).GetComponent <Hex> ();
				Hex target2 = GameObject.Find ("Hex_" + (cityx - 2 + i) + "_" + (cityy - 1)).GetComponent <Hex> ();

				food += target1.food;
				food += target2.food;
				production += target1.production;
				production += target2.production;
				biology += target1.biology;
				biology += target2.biology;
				physics += target1.physics;
				physics += target2.physics;
				engineering += target1.engineering;
				engineering += target2.engineering;
			}
			for (int x = 0; x < 2; x++) {
				Hex target1 = GameObject.Find ("Hex_" + (x + cityx + 1) + "_" + (cityy + 2)).GetComponent <Hex> ();
				Hex target2 = GameObject.Find ("Hex_" + (cityx - 1 - x) + "_" + (cityy + 2)).GetComponent <Hex> ();
				Hex target3 = GameObject.Find ("Hex_" + (x + cityx + 1) + "_" + (cityy - 2)).GetComponent <Hex> ();
				Hex target4 = GameObject.Find ("Hex_" + (cityx - 1 - x) + "_" + (cityy - 2)).GetComponent <Hex> ();

				food += target1.food;
				food += target2.food;
				production += target1.production;
				production += target2.production;
				food += target3.food;
				food += target4.food;
				production += target3.production;
				production += target4.production;
				biology += target1.biology;
				biology += target2.biology;
				biology += target3.biology;
				biology += target4.biology;
				physics += target1.physics;
				physics += target2.physics;
				physics += target3.physics;
				physics += target4.physics;
				engineering += target1.engineering;
				engineering += target2.engineering;
				engineering += target3.engineering;
				engineering += target4.engineering;
			}
			for (int i = 0; i < 4; i++) {
				Hex target1 = GameObject.Find ("Hex_" + (cityx - 1 + i) + "_" + (cityy + 3)).GetComponent <Hex> ();
				Hex target2 = GameObject.Find ("Hex_" + (cityx - 1 + i) + "_" + (cityy - 3)).GetComponent <Hex> ();

				food += target1.food;
				food += target2.food;
				production += target1.production;
				production += target2.production;
				biology += target1.biology;
				biology += target2.biology;
				physics += target1.physics;
				physics += target2.physics;
				engineering += target1.engineering;
				engineering += target2.engineering;
			}

			city.GetComponent <CityManagement> ().CityLeveler (food, production, biology, physics, engineering);
		}
	}

	public void ShowResources () {
		foodText.text = "Food: " + food;
		productionText.text = "Production: " + production;
		biologyText.text = "Biology: " + GameObject.FindGameObjectWithTag ("City").GetComponent <CityManagement> ().biology;
		physicsText.text = "Physics: " + GameObject.FindGameObjectWithTag ("City").GetComponent <CityManagement> ().physics;
		engineeringText.text = "Engineering: " + GameObject.FindGameObjectWithTag ("City").GetComponent <CityManagement> ().engineering;
	}
	#endregion

}
