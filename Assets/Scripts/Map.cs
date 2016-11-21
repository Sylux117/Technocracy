using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Map : MonoBehaviour {

	public GameObject hexPrefab;
	public GameObject selectedUnit;

	//Size of the map in terms of number of hex tiles
	//This is NOT representative of the amount of world space that we're going to take up.
	//(i.e. our tiles might be more or less than 1 Unity World Unit)
	public int width = 40;
	public int height = 25;

	float xOffset = 1.75f;
	float zOffset = 1.5f;

	public HexType[] hextypes;
	int[,] hexes;
	Node[,] graph;

	void Start () {
		GenerateMapData ();
		GenerateMapVisual ();
		GeneratePathfindingGraph ();

	}

	void GenerateMapData () {

		hexes = new int[width, height];

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				hexes [x, y] = 0;

			}
		}
		hexes [4, 4] = 2;
		hexes [5, 4] = 2;
		hexes [6, 4] = 2;
		hexes [7, 4] = 2;
		hexes [8, 4] = 2;
		hexes [4, 5] = 2;
		hexes [4, 6] = 2;
		hexes [8, 5] = 2;
		hexes [8, 6] = 2;

		hexes [4, 0] = 1;
		hexes [4, 1] = 1;
		hexes [4, 2] = 1;
		hexes [4, 3] = 1;
		hexes [5, 0] = 1;
		hexes [5, 1] = 1;
		hexes [5, 2] = 1;
		hexes [5, 3] = 1;

		hexes [5, 5] = 9;
	}

	public Hex BuildingHex (int a, Hex hex) {
		int xHex = hex.x;
		int yHex = hex.y;
		float xPos = xHex * xOffset;
		if (yHex % 2 == 1){
			xPos += xOffset / 2f;
		}

		hexes [xHex, yHex] = a;
		Destroy (hex.gameObject);
		HexType tt = hextypes [hexes [xHex, yHex]];
		GameObject hex_go = Instantiate (tt.hexVisualPrefab, new Vector3 (xPos, 0, yHex * zOffset), Quaternion.identity) as GameObject;
		hex_go.name = "Hex_" + xHex + "_" + yHex;

		hex_go.GetComponent <Hex> ().x = xHex;
		hex_go.GetComponent <Hex> ().y = yHex;

		hex_go.transform.SetParent (this.transform);

		hex_go.isStatic = true;

		GameObject.Find ("MouseManager").GetComponent <NextTurnManager> ().AddBuilding(hex_go);

		return hex_go.GetComponent <Hex> ();
	}

	public Hex ChangeHexes (int a, Hex hex) {
		int xHex = hex.x;
		int yHex = hex.y;
		float xPos = xHex * xOffset;
		if (yHex % 2 == 1){
			xPos += xOffset / 2f;
		}

		hexes [xHex, yHex] = a;
		Destroy (hex.gameObject);
		HexType tt = hextypes [hexes [xHex, yHex]];
		GameObject hex_go = Instantiate (tt.hexVisualPrefab, new Vector3 (xPos, 0, yHex * zOffset), Quaternion.identity) as GameObject;
		hex_go.name = "Hex_" + xHex + "_" + yHex;

		hex_go.GetComponent <Hex> ().x = xHex;
		hex_go.GetComponent <Hex> ().y = yHex;

		hex_go.transform.SetParent (this.transform);

		hex_go.isStatic = true;

		return hex_go.GetComponent <Hex> ();
	}

	void GenerateMapVisual () {
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {

				float xPos = x * xOffset;

				//Are we on an odd row?
				if (y % 2 == 1){
					xPos += xOffset / 2f;
				}

				HexType tt = hextypes [hexes [x, y]];

				GameObject hex_go = Instantiate (tt.hexVisualPrefab, new Vector3 (xPos, 0, y * zOffset), Quaternion.identity) as GameObject;

				hex_go.name = "Hex_" + x + "_" + y;

				hex_go.GetComponent <Hex> ().x = x;
				hex_go.GetComponent <Hex> ().y = y;

				hex_go.transform.SetParent (this.transform);

				hex_go.isStatic = true;
			}
		}	
	}

	void GeneratePathfindingGraph () {
		graph = new Node[width, height];

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				graph [x, y] = new Node ();
				graph [x, y].x = x;
				graph [x, y].y = y;
			}
		}

		for (int x = 0; x < width - 1; x++) {
			for (int y = 0; y < height - 1; y++) {
				if (x > 0) {
					graph [x, y].neighbours.Add (graph [x - 1, y]);
				}

				if (x < width - 1) {
					graph [x, y].neighbours.Add (graph [x + 1, y]);
				}

				if (y % 2 == 0) {
					if (x > 0 && y < height - 1) {
						graph [x, y].neighbours.Add (graph [x - 1, y + 1]);
					}
					if (y < height - 1) {
						graph [x, y].neighbours.Add (graph [x, y + 1]);
					}
					if (x > 0 && y > 0) {
						graph [x, y].neighbours.Add (graph [x - 1, y - 1]);
					}
					if (y > 0) {
						graph [x, y].neighbours.Add (graph [x, y - 1]);
					}
				} else if (y % 2 == 1) {
					if (y < height - 1) {
						graph [x, y].neighbours.Add (graph [x, y + 1]);
					}
					if (x < width - 1 && y < height - 1) {
						graph [x, y].neighbours.Add (graph [x + 1, y + 1]);
					}
					if (y > 0) {
						graph [x, y].neighbours.Add (graph [x, y - 1]);
					}
					if (x < width - 1 && y > 0) {
						graph [x, y].neighbours.Add (graph [x + 1, y - 1]);
					}
				}
			}
		}
	}

	public bool UnitCanEnterHex (int x, int y) {



		return hextypes [hexes [x, y]].isWalkable;
	}

	public void GeneratePathTo (int tox, int toy, int fromx, int fromy) {
		if (selectedUnit != null) {
			selectedUnit.GetComponent <Unit> ().currentPath = null;

			if (UnitCanEnterHex(tox, toy) == false) {
				return;
			}

			Dictionary <Node, float> dist = new Dictionary <Node, float> ();
			Dictionary <Node, Node> prev = new Dictionary <Node, Node> ();
			/*Node source = graph [selectedUnit.GetComponent <Unit> ().x, selectedUnit.GetComponent <Unit> ().y];*/
			Node source = graph [fromx, fromy];
			Node target = graph [tox, toy];

			List <Node> unvisited = new List <Node> ();

			dist [source] = 0;
			prev [source] = null;

			foreach (Node v in graph) {
				if (v != source) {
					dist [v] = Mathf.Infinity;
					prev [v] = null;
				}
				unvisited.Add (v);

			}

			while (unvisited.Count > 0) {
				Node u = null;

				foreach (Node possibleU in unvisited) {
					if (u == null || dist [possibleU] < dist [u]) {
						u = possibleU;
					}
				}

				if (u == target) {
					break;
				}

				unvisited.Remove (u);
				foreach (Node v in u.neighbours) {
					//float alt = dist [u] + v.DistanceTo (v);
					float alt = dist [u] + CostToEnterHex ((int)u.x, (int)u.y, (int)v.x, (int)v.y);

					if (alt < dist [v]) {
						dist [v] = alt;
						prev [v] = u;
					}
				}
			}

			if (prev [target] == null) {
				return;
			}

			List <Node> currentPath = new List<Node> ();
			Node curr = target;

			while (curr != null) {
				currentPath.Add (curr);
				curr = prev [curr];
			}

			currentPath.Reverse ();

			selectedUnit.GetComponent <Unit> ().currentPath = currentPath;
			selectedUnit.GetComponent <Unit> ().moving = true;
		}
	}

	public Vector3 HexCoordToWorldCoord (int x, int y) {
		if (y % 2 == 0) {
			return new Vector3 (x * 1.75f, 0, y * 1.5f);
		} else if (y % 2 == 1) {
			return new Vector3 ((x * 1.75f) + 0.875f, 0, y * 1.5f);
		} else {
			return new Vector3 (x, 0, y);
		}
	}

	public float CostToEnterHex (int sourceX, int sourceY, int targetX, int targetY) {
		HexType tt = hextypes [hexes [targetX, targetY]];

		if (UnitCanEnterHex (targetX, targetY) == false)
			return Mathf.Infinity;

		float cost = tt.movementCost;

		if (sourceX != targetX && sourceY != targetY) {
			cost += 0.001f;
		}

		return cost;
	}
}
