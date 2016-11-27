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
	public int[,] hexes;
	public int[] hexType;
	Node[,] graph;

	void Start () {
		GenerateMapData ();
		GenerateMapVisual ();
		GeneratePathfindingGraph ();

	}

	void GenerateMapData () {

		hexes = new int[width, height];

		#region MapData

		hexType = new int[1000] {0, 0, 0, 0, 5, 0, 0, 0, 25, 25, 5, 2, 2, 6, 1, 1, 0, 25, 0, 0, 0, 5, 0, 0, 25, 25, 5, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
								0, 0, 0, 26, 5, 0, 5, 0, 25, 0, 0, 2, 2, 2, 27, 1, 25, 25, 0, 0, 5, 5, 0, 25, 25, 26, 0, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
								0, 0, 0, 0, 3, 3, 3, 0, 0, 0, 0, 0, 2, 2, 2, 28, 1, 0, 0, 0, 0, 0, 0, 0, 0, 25, 0, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 
								0, 0, 0, 3, 3, 3, 3, 25, 0, 25, 25, 0, 26, 2, 2, 2, 1, 0, 0, 5, 28, 1, 27, 25, 0, 0, 0, 0, 0, 26, 25, 3, 3, 3, 3, 3, 3, 3, 3, 3,
								0, 0, 0, 3, 3, 3, 3, 25, 25, 0, 25, 25, 26, 0, 2, 2, 2, 6, 26, 2, 2, 1, 1, 27, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 3,
								0, 0, 3, 3, 3, 3, 2, 28, 1, 1, 25, 25, 0, 0, 26, 2, 1, 0, 0, 2, 2, 6, 1, 1, 28, 25, 0, 5, 0, 0, 0, 0, 25, 0, 0, 5, 0, 3, 3, 3,
								0, 0, 0, 3, 3, 3, 2, 2, 2, 1, 1, 0, 0, 0, 0, 0, 1, 0, 25, 2, 2, 2, 2, 1, 1, 25, 0, 0, 0, 0, 0, 25, 25, 25, 0, 1, 1, 1, 0, 0, 
								0, 0, 0, 25, 25, 2, 2, 2, 2, 1, 1, 0, 5, 5, 0, 0, 25, 25, 0, 2, 2, 2, 2, 6, 1, 0, 0, 5, 0, 0, 25, 25, 0, 0, 1, 1, 1, 0, 0, 0, 
								0, 0, 0, 0, 26, 2, 2, 2, 2, 1, 1, 1, 0, 0, 0, 0, 0, 0, 5, 26, 25, 26, 2, 2, 28, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 
								0, 0, 0, 0, 0, 0, 0, 0, 1, 6, 1, 27, 25, 25, 0, 0, 0, 5, 25, 0, 25, 28, 6, 6, 27, 1, 0, 0, 0, 5, 5, 2, 28, 1, 1, 1, 1, 0, 0, 0, 
								2, 0, 0, 0, 0, 25, 25, 0, 0, 1, 1, 1, 1, 26, 0, 25, 25, 25, 25, 25, 0, 26, 6, 1, 1, 1, 1, 26, 0, 0, 0, 2, 2, 6, 1, 1, 1, 1, 0, 0, 
								2, 0, 0, 0, 0, 0, 0, 0, 1, 27, 27, 1, 0, 0, 0, 25, 0, 25, 0, 4, 25, 5, 6, 1, 1, 27, 0, 0, 0, 0, 0, 2, 2, 1, 1, 1, 0, 0, 0, 0, 
								2, 2, 0, 0, 25, 0, 2, 2, 6, 1, 27, 5, 0, 0, 0, 0, 0, 0, 0, 25, 0, 5, 6, 1, 1, 27, 25, 0, 0, 6, 1, 1, 1, 1, 1, 27, 1, 0, 0, 0, 
								1, 1, 1, 0, 0, 2, 2, 6, 1, 1, 1, 0, 25, 5, 25, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 5, 0, 1, 1, 1, 1, 1, 1, 6, 6, 0, 0, 0, 0, 
								2, 1, 1, 1, 0, 5, 2, 2, 6, 1, 1, 0, 0, 5, 0, 0, 0, 0, 0, 0, 5, 1, 1, 1, 0, 0, 0, 0, 1, 1, 27, 1, 1, 1, 1, 1, 0, 0, 0, 0,
								1, 1, 1, 0, 0, 0, 2, 2, 27, 0, 25, 25, 0, 0, 0, 0, 25, 0, 0, 0, 0, 0, 0, 26, 0, 0, 0, 1, 1, 27, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 
								1, 1, 1, 1, 1, 0, 0, 25, 0, 0, 0, 5, 0, 0, 0, 25, 25, 0, 0, 0, 0, 0, 0, 0, 2, 6, 27, 1, 1, 1, 1, 1, 27, 27, 6, 1, 0, 0, 0, 0, 
								1, 1, 1, 1, 6, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 26, 0, 0, 0, 2, 28, 1, 1, 6, 27, 1, 27, 27, 28, 1, 0, 0, 0, 0, 0, 
								1, 1, 1, 1, 1, 0, 25, 0, 3, 3, 25, 25, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 1, 1, 6, 1, 1, 27, 6, 0, 0, 0, 0, 0, 0, 
								1, 1, 1, 1, 0, 25, 0, 3, 3, 3, 25, 0, 0, 0, 0, 0, 0, 25, 0, 25, 25, 0, 0, 0, 2, 6, 1, 1, 1, 1, 1, 1, 6, 1, 0, 0, 0, 0, 0, 0, 
								0, 1, 1, 0, 5, 0, 0, 3, 3, 3, 3, 3, 25, 26, 2, 2, 2, 1, 0, 25, 25, 0, 0, 5, 0, 0, 0, 26, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 
								0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 2, 2, 2, 2, 2, 28, 1, 1, 0, 0, 0, 5, 26, 0, 0, 0, 0, 0, 2, 6, 27, 1, 1, 1, 1, 25, 0, 0, 0, 0,
								0, 0, 0, 0, 0, 0, 25, 3, 3, 3, 2, 2, 2, 2, 2, 6, 1, 1, 27, 0, 0, 25, 25, 25, 25, 0, 0, 0, 0, 2, 2, 6, 27, 1, 1, 27, 25, 0, 0, 0,
								0, 0, 0, 5, 5, 25, 5, 25, 25, 25, 5, 26, 2, 2, 2, 6, 1, 1, 0, 0, 5, 26, 25, 25, 26, 5, 0, 0, 0, 2, 2, 2, 27, 1, 1, 25, 0, 0, 0, 0,
								0, 0, 0, 0, 26, 25, 25, 25, 25, 25, 25, 5, 5, 2, 2, 2, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 6, 1, 1, 0, 0, 0, 0, 0};

		#endregion

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				hexes [x, y] = hexType[x + (y * 40)];
			}
		}
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
		hex_go.GetComponent <Hex> ().hexType = a;
		hex_go.GetComponent <Hex> ().CalculateResources ();

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

	public int HexDistance (int x1, int y1, int x2, int y2) {
		int dx = x2 - x1;
		int dy = y2 - y1;
		int x = Mathf.Abs (dx);
		int y = Mathf.Abs (dy);

		if ((dx < 0) ^ ((y1 & 1) == 1))
			x = Mathf.Max (0, x - (y + 1) / 2);
		else
			x = Mathf.Max (0, x - (y) / 2);
		return x + y;
	}
}
