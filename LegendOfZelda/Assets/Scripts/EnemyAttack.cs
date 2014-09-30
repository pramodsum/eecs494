
using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
	
		public GameObject attack, attack2, attack3;
		public float shootSpeed = 7.5f;
		public float shootAngle;
		float deltaTime = 0;

		// Use this for initialization
		void Start ()
		{
		
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				deltaTime += Time.fixedDeltaTime;
				if (deltaTime > 1.0f) {
						deltaTime = 0;

						//Forward
						GameObject currentAttack = Instantiate (attack, transform.position + new Vector3 (-Vector2.right.x, -Vector2.right.y, 0), Quaternion.identity) as GameObject;
						currentAttack.rigidbody2D.velocity = -Vector2.right * shootSpeed;
						
						//Up
						GameObject currentAttack2 = Instantiate (attack2, transform.position + new Vector3 (Vector2.up.x, Vector2.up.y, 0), Quaternion.Euler (new Vector3 (0, 30, 0))) as GameObject;
						currentAttack2.rigidbody2D.velocity = Vector2.up * shootSpeed;	

						//Down
						GameObject currentAttack3 = Instantiate (attack3, transform.position + new Vector3 (-Vector2.up.x, -Vector2.up.y, 0), Quaternion.Euler (new Vector3 (0, -30, 0))) as GameObject;
						currentAttack3.rigidbody2D.velocity = -Vector2.up * shootSpeed;	
				}
		}
	
}
