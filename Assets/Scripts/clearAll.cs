using UnityEngine;
using System.Collections;

public class clearAll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void ClearAll () {
			GameObject[] planets = GameObject.FindGameObjectsWithTag("planet");
			foreach (GameObject planet in planets) {
				Destroy (planet.gameObject);
			}
	}
}
