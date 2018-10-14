using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject bullet;
    public float bulletSpeed;
    float timer;
  


    void shoot()
    {
        GameObject shot = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
        shot.GetComponent<Rigidbody>().velocity = Vector3.left * bulletSpeed;
        Destroy(shot, 2.0f);
    }

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
         timer += Time.deltaTime;
	      if (Input.GetButton("Fire1") && timer > 2f) {
            shoot();
            timer = 0;
        }
    

    }
}
