using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Unit : MonoBehaviour {

	#region Variables
	public int x;
	public int y;
	public Map map;

	public Vector3 destination;

	float speed = 3;

	public List <Node> currentPath = null;

	public bool isSelected;
	public GameObject selected;

	public bool moving;

	public int moveSpeed;

	private Vector3 dir;

	public int isBeingTrained;

	public GameObject unitCanvas;
	public bool waiting;
	private GameObject UnitCanvas;
	public bool CombatUnit;
	public bool SecurityForces;
	public bool Scientist;
	#endregion

	void Start () {
		map = GameObject.Find ("Generated_map").GetComponent <Map> ();
		moving = false;
		UnitCanvas = Instantiate (unitCanvas, Vector3.zero, Quaternion.identity) as GameObject;
		UnitCanvas.gameObject.SetActive (false);
		UnitCanvas.gameObject.GetComponent <UnitCanvas> ().unit = this.gameObject;
		UnitCanvas.transform.SetParent (this.gameObject.transform);
	}

	void Update () {
		
		if (currentPath != null) {
			int currNode = 0;

			while (currNode < currentPath.Count - 1) {
				Vector3 start = map.HexCoordToWorldCoord((int)currentPath[currNode].x, (int)currentPath[currNode].y) + new Vector3 (0, 1, 0);
				Vector3 end = map.HexCoordToWorldCoord((int)currentPath[currNode + 1].x, (int)currentPath[currNode + 1].y) + new Vector3 (0, 1, 0);
				Debug.DrawLine (start, end, Color.red);
				currNode++;
			}
		}

		if (isSelected == true) {
			selected.SetActive (true);
			UnitCanvas.SetActive (true);
		} else {
			selected.SetActive (false);
			UnitCanvas.SetActive (false);
		}

		if (moving == true) {
			waiting = false;
			UnitCanvas.gameObject.GetComponentInChildren <Toggle> ().isOn = false;
		}

	}

	#region Functions
	public void MoveNextHex () {
		float remainingMovement = moveSpeed;
		while (remainingMovement > 0 && moving == true) {
			if (currentPath == null)
				return;

			remainingMovement -= map.CostToEnterHex((int)currentPath [0].x, (int)currentPath [0].y, (int)currentPath [1].x, (int)currentPath [1].y);
			x = (int)currentPath [1].x;
			y = (int)currentPath [1].y;
			transform.position = map.HexCoordToWorldCoord (x, y);
			currentPath.RemoveAt (0);

			if (currentPath.Count == 1) {
				currentPath = null;
				moving = false;
			}
		}
	}

	void setDestination (Vector3 dir) {
		dir = destination - transform.position;
		Vector3 velocity = dir.normalized * speed * Time.deltaTime;
		velocity = Vector3.ClampMagnitude (velocity, dir.magnitude);
		transform.Translate (velocity);
	}
	#endregion
}
