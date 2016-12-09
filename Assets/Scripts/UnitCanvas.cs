using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnitCanvas : MonoBehaviour {

	public GameObject unit;

	void Update () {
		unit.GetComponent <Unit> ().waiting = this.gameObject.GetComponentInChildren <Toggle> ().isOn;
	}

}
