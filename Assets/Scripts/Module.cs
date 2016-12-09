using UnityEngine;
using System.Collections;

public class Module : MonoBehaviour {

	public GameObject[] units;
	private float biology = 10;
	private float engineering = 10;
	private float physics = 10;

	void Update () {
		units = GameObject.FindGameObjectsWithTag ("Unit");
		for (int i = 0; i < units.Length; i++) {
			if (units [i].GetComponent <Unit> ().x == this.gameObject.GetComponent <Hex> ().x) {
				if (units [i].GetComponent <Unit> ().y == this.gameObject.GetComponent <Hex> ().y) {
					if (units [i].GetComponent <Unit> ().Scientist == true){
						GameObject.FindGameObjectWithTag ("City").GetComponent <CityManagement> ().biology += biology;
						GameObject.FindGameObjectWithTag ("City").GetComponent <CityManagement> ().engineering += engineering;
						GameObject.FindGameObjectWithTag ("City").GetComponent <CityManagement> ().physics += physics;
						Destroy (units [i].gameObject);
						if (this.gameObject.GetComponent <Hex> ().hexType == 49) {
							GameObject.Find ("Generated_map").GetComponent <Map> ().ChangeHexes (0, this.gameObject.GetComponent <Hex> ());
						}
						if (this.gameObject.GetComponent <Hex> ().hexType == 51) {
							GameObject.Find ("Generated_map").GetComponent <Map> ().ChangeHexes (1, this.gameObject.GetComponent <Hex> ());
						}
					}
				}
			}
		}
	}
}
