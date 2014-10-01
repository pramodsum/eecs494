using UnityEngine;
using System.Collections;

public enum Direction {
	Up,
	Down,
	Left,
	Right
}

public class SmartEnemyMovement : MonoBehaviour
{

		GameObject player;
	public Direction WatchDirection = Direction.Up;
		public Vector2 movementDirection = Vector2.zero;
		float speed = 0;
		public bool playerClose = false;
		public Vector3 startPosition;
	public float travelDistance;

		void Start ()
		{
		startPosition = transform.position;

			if(WatchDirection == Direction.Up){
				movementDirection = Vector2.up;
			    travelDistance = 3;
			}
			if(WatchDirection == Direction.Down){
				movementDirection = -Vector2.up;
			travelDistance = 3;

			}
			if(WatchDirection == Direction.Left){
				movementDirection = -Vector2.right;
			travelDistance = 5;

			}
			if(WatchDirection == Direction.Right){
				movementDirection = Vector2.right;
			travelDistance = 5;
			}
		}

		void FixedUpdate ()
		{
			Color color = Color.red;
			Debug.DrawRay (transform.position, Vector2.up, Color.green);
			Debug.DrawRay (transform.position, -Vector2.up, Color.green);
			Debug.DrawRay (transform.position, Vector2.right, Color.green);
			Debug.DrawRay (transform.position, -Vector2.right, Color.green);

		collider2D.enabled = false;

		RaycastHit2D hit = Physics2D.Raycast (transform.position, movementDirection);
				Debug.DrawRay (transform.position, movementDirection, color);
				playerClose = hit.collider != null && hit.collider.tag == "Player";
		collider2D.enabled = true;

		if( playerClose && Mathf.Abs(transform.position.magnitude - startPosition.magnitude) < travelDistance ){
			if(WatchDirection == Direction.Up || WatchDirection == Direction.Down ){
				speed += .5f;
			} else {
				speed += 1.5f;
			}
		}


		if( !playerClose &&  Mathf.Abs(transform.position.magnitude - startPosition.magnitude) >= travelDistance ) {
				speed = -2f;
				playerClose = false;
			}
		if(!playerClose && transform.position.magnitude - startPosition.magnitude > 0 )
			speed = 0f;

			rigidbody2D.velocity = movementDirection * speed;

		}
}
