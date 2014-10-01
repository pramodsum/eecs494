using UnityEngine;
using System.Collections;

public class SwordCollision : MonoBehaviour {

	void Start( ) {
		if( rigidbody2D.velocity == Vector2.zero ) StartCoroutine("Melee");
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.GetComponent<PhysicsObject>().ObjectType == PhysicsObjectType.Enemy){
			collider.GetComponent<EnemyDeath>().Hit();
		}
		if(collider.tag != "Water")
			Destroy(gameObject);
	}

	IEnumerator Melee(){
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
	}
}
