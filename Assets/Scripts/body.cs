using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Transform))]

public class body : MonoBehaviour {
	public Transform _transform;
	public float mass = 1f;
	public Vector2 velocity = Vector2.zero;
	public Vector2 initalForwardSpeed = Vector2.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
