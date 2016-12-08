using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	void DestroyObject () 
	{
		Destroy (this.gameObject.transform.parent.gameObject);
	}

}
