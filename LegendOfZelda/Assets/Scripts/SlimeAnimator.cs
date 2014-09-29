using UnityEngine;
using System.Collections;

public class SlimeAnimator : MonoBehaviour
{
		public float moveSpeed;
		public int direction; // { up, down, right, left }
		Vector3 colliderPosition;

	Vector2 movementDirection;
	float deltaTime = 0;

		// Update is called once per frame
		void FixedUpdate ()
		{		
		deltaTime += Time.fixedDeltaTime;
		if( deltaTime > 3.0f){
			direction = Random.Range (0, 3);
			deltaTime = 0f;
		}

		if (direction == 0)
			movementDirection = Vector2.up;
		else if (direction == 1)
			movementDirection = -Vector2.up;
		else if (direction == 2)
			movementDirection = Vector2.right;
		else 
			movementDirection = -Vector2.right;
		
		rigidbody2D.velocity = movementDirection * moveSpeed;
		}
	
	
		void OnTriggerEnter2D (Collider2D collider)
		{
		if( collider.tag == "Player"){
			Camera.main.GetComponent<HealthScript>().Hit();
		}
		if(collider.tag != "Weapon"){
			transform.position -= (new Vector3(movementDirection.x, movementDirection.y, 0)) * .2f;
			movementDirection = Vector2.zero;
			//Change direction when enemy collides with something
			direction += 1;
			direction %= 4;
		}
		}
}
