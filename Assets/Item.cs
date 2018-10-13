using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public GameObject pickUp;
    

    void OnTriggerEnter(Collider rb)
    {
        if (rb.gameObject.tag == "Player") { 
        rb.gameObject.GetComponent<Player>().itemCount++;
        Destroy(gameObject);
    }
    }
    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
