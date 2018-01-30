using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	public int speedZ = 0;
	public int speedX = 0;
	private bool planetForce = true;


	// Use this for initialization
	void Start () {
		Vector3 initial = new Vector3 (speedX, 0, speedZ);

		this.GetComponent<Rigidbody>().AddForce(initial);
	}

	// Update is called once per frame
	void FixedUpdate () {
//		Vector3 initial = new Vector3 (speedX, 0, speedZ);
//
//		this.GetComponent<Rigidbody>().AddForce(initial);
		
	}
}
