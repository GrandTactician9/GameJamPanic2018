using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
	public Transform player;
	public int enemyHealth;
	public List <Transform> patrolSpots;
	int current = 0;
	public float restTime = 2f;
	NavMeshAgent agent;


	public int EnemyHealth {
		
		set{ enemyHealth = value;
			if (enemyHealth <= 0) {
				Destroy (gameObject, 1f);
			}}
	}

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.SetDestination (patrolSpots [current].position);
		if (patrolSpots.Count < 2) {
			Debug.Log(gameObject.name + " Don't have destination ");
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (player != null) {
			Debug.Log("Found enemy");
			if (restTime >= 0f) {
				restTime -= Time.deltaTime;
				agent.speed = 0;
			} else {
				agent.speed = 70f;
			}
					agent.SetDestination (player.position);					
		
		} else {
			agent.speed = 70;
			//Debug.Log (agent.remainingDistance);
			if (agent.remainingDistance < 1f) {
				current++;
				if (current > patrolSpots.Count - 1) {
					current = 0;
				}
				agent.SetDestination (patrolSpots [current].position);

			}

		}

	}
		
	void OnCollisionStay(Collision obj){
		if (obj.gameObject.CompareTag("Player")) {
			Debug.Log ("Need Rest");
			obj.gameObject.GetComponent<Player> ().getHurt ();
			restTime = 2f;
		}
	}

}
