using UnityEngine;
using System.Collections;

public class EnemyAttackCollision : MonoBehaviour
{
	
		void Start ()
		{
		}
	
		void OnTriggerEnter2D (Collider2D collider)
		{
				Destroy (gameObject);
				if (collider.GetComponent<PhysicsObject> ().ObjectType == PhysicsObjectType.Player) {
						Camera.main.GetComponent<HealthScript> ().Hit ();
				}
		}
}
