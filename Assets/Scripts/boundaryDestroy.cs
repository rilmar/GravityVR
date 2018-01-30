using UnityEngine;
using System.Collections;

public class boundaryDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}
	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
	}
}
