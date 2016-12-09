using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject[] units;

	void Update () {
		units = GameObject.FindGameObjectsWithTag ("Unit");
		for (int i = 0; i < units.Length; i++) {
			if (units [i].GetComponent <Unit> ().x == this.gameObject.GetComponent <Hex> ().x) {
				if (units [i].GetComponent <Unit> ().y == this.gameObject.GetComponent <Hex> ().y) {
					if (units [i].GetComponent <Unit> ().CombatUnit == false){
						Destroy (units [i].gameObject);
					} else if (units [i].GetComponent <Unit> ().CombatUnit == true) {
						if (units [i].GetComponent <Unit> ().SecurityForces == false) {
							Destroy (units [i].gameObject);
							if (this.gameObject.GetComponent <Hex> ().hexType == 53) {
								GameObject.Find ("Generated_map").GetComponent <Map> ().ChangeHexes (0, this.gameObject.GetComponent <Hex> ());
							}
							if (this.gameObject.GetComponent <Hex> ().hexType == 55) {
								GameObject.Find ("Generated_map").GetComponent <Map> ().ChangeHexes (1, this.gameObject.GetComponent <Hex> ());
							}
						} else if (units [i].GetComponent <Unit> ().SecurityForces == true) {
							if (this.gameObject.GetComponent <Hex> ().hexType == 53) {
								GameObject.Find ("Generated_map").GetComponent <Map> ().ChangeHexes (0, this.gameObject.GetComponent <Hex> ());
							}
							if (this.gameObject.GetComponent <Hex> ().hexType == 55) {
								GameObject.Find ("Generated_map").GetComponent <Map> ().ChangeHexes (1, this.gameObject.GetComponent <Hex> ());
							}
						}
					}
				}
			}
		}
	}
}
