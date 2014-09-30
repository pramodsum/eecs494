using UnityEngine;
using System.Collections;

public class EnemyAttackCollision : MonoBehaviour
{
	
		void Start ()
		{
		}
	
		void OnTriggerEnter2D (Collider2D collider)
		{
				if (collider.GetComponent<PhysicsObject> ().ObjectType == PhysicsObjectType.Player) {
						Camera.main.GetComponent<HealthScript> ().Hit ();
				}
				Destroy (gameObject);
		}
}
