using UnityEngine;
using System.Collections;

public class CustomEnemyAttack : MonoBehaviour
{
	
		public GameObject[] attack;
		public float shootSpeed = 7.5f;
		float deltaTime = 0;
	
		// Use this for initialization
		void Start ()
		{
		
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				deltaTime += Time.fixedDeltaTime;
				if (deltaTime > 1f) {
						deltaTime = 0;

						//Up
						GameObject currentAttack2 = Instantiate (attack [Random.Range (0, 3)], transform.position + new Vector3 (Vector2.up.x, Vector2.up.y, 0), Quaternion.identity) as GameObject;
						currentAttack2.rigidbody2D.velocity += Vector2.up * shootSpeed;	
				}
		}
}
