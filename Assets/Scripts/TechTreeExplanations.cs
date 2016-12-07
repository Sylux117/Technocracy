using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class TechTreeExplanations : MonoBehaviour {

	private GameObject image;

	void Start () {
		image = GameObject.Find (this.gameObject.name + "Image");
		image.SetActive (false);
	}

	public void OpenExplanation () {
		image.SetActive (true);
	}

}
