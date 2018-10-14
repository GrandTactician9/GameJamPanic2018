using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

	private void OnTriggerEnter(Collider obj){
		if (obj.CompareTag("Player")) {
			transform.GetComponentInParent<Enemy>().player = obj.gameObject.transform;				
		}
	}


}
