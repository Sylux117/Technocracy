using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorldCamera : MonoBehaviour {

	private float cameraMoveSpeed 	= 0.5f;

	void Update () {
		if (Input.GetKey(KeyCode.W) && this.transform.position.z < 36) {
			this.transform.Translate (0, 0, cameraMoveSpeed);
		}
		if (Input.GetKey(KeyCode.S) && this.transform.position.z > -7) {
			this.transform.Translate (0, 0, -cameraMoveSpeed);
		}
		if (Input.GetKey(KeyCode.A) && this.transform.position.x > 5) {
			this.transform.Translate (-cameraMoveSpeed, 0, 0);
		}
		if (Input.GetKey(KeyCode.D) && this.transform.position.x < 70) {
			this.transform.Translate (cameraMoveSpeed, 0, 0);
		}

		if (Input.mousePosition.y > Screen.height - 10 && this.transform.position.z < 36) {
			this.transform.Translate (0, 0, cameraMoveSpeed);
		}
		if (Input.mousePosition.y < 10 && this.transform.position.z > -7) {
			this.transform.Translate (0, 0, -cameraMoveSpeed);
		}
		if (Input.mousePosition.x > Screen.width - 10 && this.transform.position.x < 70) {
			this.transform.Translate (cameraMoveSpeed, 0, 0);
		}
		if (Input.mousePosition.x < 10 && this.transform.position.x > 5) {
			this.transform.Translate (-cameraMoveSpeed, 0, 0);
		}
	}
}
