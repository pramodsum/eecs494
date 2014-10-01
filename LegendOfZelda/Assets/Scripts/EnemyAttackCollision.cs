using UnityEngine;
using System.Collections;

public class EnemyAttackCollision : MonoBehaviour
{
	
		void Start ()
		{
		}
	
		void OnTriggerEnter2D (Collider2D collider)
		{
		PhysicsObject po = collider.GetComponent<PhysicsObject>() as PhysicsObject;
		if( po == null ) return;
				if (po.ObjectType == PhysicsObjectType.Player) {
						Camera.main.GetComponent<HealthScript> ().Hit ();
				}
			Destroy (gameObject);

		}
}
