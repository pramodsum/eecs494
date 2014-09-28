using UnityEngine;
using System.Collections;

public class SwordCollision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.tag == "Enemy"){
			collider.GetComponent<EnemyDeath>().Hit();
			Destroy(gameObject);
		}
		else if(collider.GetComponent<PhysicsObject>().ObjectType == PhysicsObjectType.Immovable){
			Destroy(gameObject);
		}
	}
}
