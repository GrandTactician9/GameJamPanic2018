using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject enemy;
    public float spawner;
    public float x;
    public float y;

    void randomValues()
    {
        spawner = Random.value * 30;
        x = Random.value * 20;
        y = Random.value * 20;
    }

	// Use this for initialization
	void Start () {
        GameObject game = (GameObject)Instantiate (enemy, transform.position, transform.rotation);
        randomValues();

    }
	
	// Update is called once per frame
	void Update () {
        if(spawner > 20)
        {
            GameObject game = (GameObject)Instantiate(enemy, transform.position, transform.rotation);
            randomValues();
        }
    }
}


