using UnityEngine;
using System.Collections;

public class SmartEnemyMovement : MonoBehaviour
{
		GameObject player;
		public Vector2 movementDirection = -Vector2.right;
		float vspeed = 0, hspeed = 0;
		public bool playerClose = false;
		public Vector2 position;

		void Start ()
		{
				player = GameObject.Find ("Player");

		}

		void FixedUpdate ()
		{
				position = transform.position;
				Color color = Color.red;
				Debug.DrawRay (transform.position, Vector2.up, Color.green);
				Debug.DrawRay (transform.position, -Vector2.up, Color.green);
				Debug.DrawRay (transform.position, Vector2.right, Color.green);
				Debug.DrawRay (transform.position, -Vector2.right, Color.green);

				Ray ray = Camera.main.ScreenPointToRay (transform.position);
				if (Physics2D.GetRayIntersection (ray, 100).collider.CompareTag ("Player")) {
						Debug.DrawRay (transform.position, Vector2.up, color);
						playerClose = true;
						movementDirection = Vector2.up;
						rigidbody2D.velocity = movementDirection * vspeed * Time.deltaTime;
						vspeed += 5f;
						hspeed = 0;
				} else if (Physics2D.GetRayIntersection (ray, 100).collider.CompareTag ("Player")) {
						Debug.DrawRay (transform.position, -Vector2.up, color);
						playerClose = true;
						movementDirection = -Vector2.up;
						rigidbody2D.velocity = movementDirection * vspeed * Time.deltaTime;
						vspeed += 5f;
						hspeed = 0;
				} else if (Physics2D.GetRayIntersection (ray, 100).collider.CompareTag ("Player")) {
						Debug.DrawRay (transform.position, Vector2.right, color);
						playerClose = true;
						movementDirection = Vector2.right;
						rigidbody2D.velocity = movementDirection * hspeed * Time.deltaTime;
						hspeed += 5f;
						vspeed = 0;
				} else if (Physics2D.GetRayIntersection (ray, 100).collider.CompareTag ("Player")) {
						Debug.DrawRay (transform.position, -Vector2.right, color);
						playerClose = true;
						movementDirection = -Vector2.right;
						rigidbody2D.velocity = movementDirection * hspeed * Time.deltaTime;
						hspeed += 5f;
						vspeed = 0;
				} else {
						playerClose = false;
				}
		}
}
