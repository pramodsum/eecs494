using UnityEngine;
using System.Collections;


public class PlayerAnimator : MonoBehaviour
{
		public Sprite[] sprites;
		public float framesPerSecond;
		bool collisionTrigger = false;
		private SpriteRenderer spriteRenderer;
		const  float DefaultMovespeed = 7.5f;
		public float moveSpeed;
		private Vector3 moveDirection;
		int directionIndex = 0; // down: 0, left: 1, up: 2, right: 3
		bool movingRight = false;
		bool movingLeft = false;
		bool movingUp = false;
		bool movingDown = false;
		bool colliding = false;
		Vector3 colliderPosition;
		int index = 0;


		// Use this for initialization
		void Start ()
		{
				spriteRenderer = renderer as SpriteRenderer;
		}

		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
						if (!(colliding && colliderPosition.x > transform.position.x))
								movingRight = true;
						directionIndex = 1;
				} 
				if (Input.GetKey (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
						if (!(colliding && colliderPosition.x < transform.position.x))
								movingLeft = true;
						directionIndex = 3;
				} 
				if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
						if (!(colliding && colliderPosition.y > transform.position.y))
								movingUp = true;
						directionIndex = 2;
				} 
				if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
						if (!(colliding && colliderPosition.y < transform.position.y))
								movingDown = true;
						directionIndex = 0;
				}
				if (Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.RightArrow)) {
						movingRight = false;
				} 
				if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.LeftArrow)) {
						movingLeft = false;
				} 
				if (Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.UpArrow)) {
						movingUp = false;
				} 
				if (Input.GetKeyUp (KeyCode.S) || Input.GetKeyUp (KeyCode.DownArrow)) {
						movingDown = false;
				}

				//Attack
				if (Input.GetKey (KeyCode.Z) || Input.GetKey (KeyCode.K)) {
						//slash sword
						print ("SLASH!");

				} else if (Input.GetKey (KeyCode.X) || Input.GetKey (KeyCode.L)) {
						//use special weapon
						print ("BOOM! POW! KABOOM!");
				}
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				//Sprite walking animations
				int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
				index = index % sprites.Length % 2;
				spriteRenderer.sprite = sprites [directionIndex * 2 + index];
				// 1
				Vector3 currentPosition = transform.position;
				// 2
				if (movingRight) {
						transform.Translate (-1 * Vector2.right * moveSpeed / 100);
				} 
				if (movingLeft) {
						transform.Translate (Vector2.right * moveSpeed / 100);
				}
				if (movingUp) {
						transform.Translate (Vector2.up * moveSpeed / 100);
				} 
				if (movingDown) {
						transform.Translate (-1 * Vector2.up * moveSpeed / 100);
				}
		}

		void OnTriggerEnter2D (Collider2D collider)
		{
				if (collider.tag == "Immovable") {
						colliding = true;
						Bounds immovableBounds = collider.GetComponent<BoxCollider2D> ().bounds;
						Ray upRay = new Ray (transform.position, Vector3.up);
						Ray downRay = new Ray (transform.position, Vector3.down);
						Ray leftRay = new Ray (transform.position, Vector3.left);
						Ray rightRay = new Ray (transform.position, Vector3.right);
						if (movingDown && immovableBounds.IntersectRay (downRay))
								movingDown = false;
						if (movingUp && immovableBounds.IntersectRay (upRay))
								movingUp = false;
						if (movingLeft && immovableBounds.IntersectRay (leftRay))
								movingLeft = false;
						if (movingRight && immovableBounds.IntersectRay (rightRay))
								movingRight = false;
				}
		}

		void OnTriggerStay2D (Collider2D collider)
		{
				if (collider.tag == "Immovable") {
						colliding = true;
						Bounds immovableBounds = collider.bounds;
						Ray upRay = new Ray (transform.position, Vector3.up);
						Ray downRay = new Ray (transform.position, Vector3.down);
						Ray leftRay = new Ray (transform.position, Vector3.left);
						Ray rightRay = new Ray (transform.position, Vector3.right);
						if (movingDown && immovableBounds.IntersectRay (downRay))
								movingDown = false;
						if (movingUp && immovableBounds.IntersectRay (upRay))
								movingUp = false;
						if (movingLeft && immovableBounds.IntersectRay (leftRay))
								movingLeft = false;
						if (movingRight && immovableBounds.IntersectRay (rightRay))
								movingRight = false;
				}
		}

		void OnTriggerExit2D (Collider2D collider)
		{

				colliding = false;
		}
}
