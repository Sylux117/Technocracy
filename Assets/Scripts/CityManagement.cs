using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CityManagement : MonoBehaviour {

	public GameObject canvas;
	public Hex hex;
	public int range = 3;

	void Start () {
		canvas = GameObject.Find("CityCanvas").gameObject;
		canvas.SetActive (false);
		hex = this.gameObject.GetComponent <Hex> ();
	}

	void Update () {
		if (hex.isSelected == true) {
			canvas.SetActive (true);
		} else {
			canvas.SetActive (false);
		}
	}
	
}
