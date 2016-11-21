using UnityEngine;
using System.Collections;

[System.Serializable]
public class HexType {

	public string name;
	public GameObject hexVisualPrefab;

	public bool isWalkable = true;
	public float movementCost = 1;
}
