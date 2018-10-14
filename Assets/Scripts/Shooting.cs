using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
	public float rotateSpeed;
    public GameObject bullet;
    public float bulletSpeed;
    float timer;
	public float distance = 5;
	float angle = 0;
    void shoot()
    {
            GameObject shot = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
		float x = distance * Mathf.Cos ( angle/Mathf.PI);
		float y = distance * Mathf.Sin ( angle / Mathf.PI);
		Vector3 bulletDirect= new Vector3 (x, y, 1f);
		Debug.Log (x + " " + y);
		shot.GetComponent<Rigidbody>().AddRelativeForce(bulletDirect * bulletSpeed);
		Debug.Log (shot.GetComponent<Rigidbody>().velocity);
	        Destroy(shot, 2.0f);
   	 
    }

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody>();
		Rotate (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey( KeyCode.Q)) {
			Rotate (false);
		} else if (Input.GetKey( KeyCode.E)) {
			Rotate (true);
		}

         timer += Time.deltaTime;
	      if (Input.GetButton("Fire1") && timer > 2f) {
            shoot();
            timer = 0;
        }
        
	}
	void Rotate(bool left){
		
		if (left) {
			angle -= Time.deltaTime * rotateSpeed;
		} else {
			angle += Time.deltaTime * rotateSpeed;
			}
		float x = distance * Mathf.Cos ( angle/Mathf.PI);
		float y = distance * Mathf.Sin ( angle / Mathf.PI);
		transform.localPosition = new Vector3 (x, 1f, y);
		if (x < 0) {
			transform.eulerAngles = new Vector3 (0f, 180f, 0f);	
		} else {
			transform.eulerAngles = new Vector3 (0f, 0f, 0f);	
		}
	}
}
