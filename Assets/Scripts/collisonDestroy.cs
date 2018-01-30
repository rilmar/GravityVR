using UnityEngine;
using System.Collections;

public class collisonDestroy : MonoBehaviour {

	public ParticleSystem explosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other)
	{
		if ( other.tag == "planet") {
			Vector3 origin = new Vector3 (0, 0, 0);
			Destroy(other.gameObject);
		}
	}


}
