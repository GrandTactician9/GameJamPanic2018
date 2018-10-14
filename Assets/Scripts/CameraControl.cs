using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
	public GameObject player;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dest = player.transform.position + offset;
		transform.position = Vector3.Lerp (transform.position, dest, Time.deltaTime);
	}
}
