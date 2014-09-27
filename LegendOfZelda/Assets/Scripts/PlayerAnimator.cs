using UnityEngine;
using System.Collections;


public class PlayerAnimator : MonoBehaviour
{
		public Sprite[] sprites;
		public Sprite[] attackSprites;
		public Sprite[] hurtSprites;
		public float framesPerSecond;
		private SpriteRenderer spriteRenderer;
		const  float DefaultMovespeed = 7.5f;
		const float moveSpeed = 7.5f;
		public Vector2 movementDirection;
		int directionIndex = 0;
		int index = 0;

		// Use this for initialization
		void Start ()
		{
				spriteRenderer = renderer as SpriteRenderer;
		}

		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
						movementDirection = Vector2.right;
						directionIndex = 1;
				} 
				if (Input.GetKey (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
						movementDirection = -Vector2.right;
						directionIndex = 3;
				} 
				if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
						movementDirection = Vector2.up;
						directionIndex = 2;
				} 
				if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
						movementDirection = -Vector2.up;
						directionIndex = 0;
				}
		
				if (Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.K)) {
						Debug.Log ("I SLASH YOU WITH MY SWORD!");
						spriteRenderer.sprite = attackSprites [directionIndex];
						//						isAttacking = true;
//						attack ();
				}
				if (Input.GetKeyDown (KeyCode.X) || Input.GetKeyDown (KeyCode.L)) {
						Debug.Log ("BOOM! CLASH! POW!");
						//						isAttacking = true;
				}
		
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				if (!Input.GetKey (KeyCode.D) && 
						!Input.GetKey (KeyCode.RightArrow) && 
						!Input.GetKey (KeyCode.A) &&
						!Input.GetKey (KeyCode.LeftArrow) &&
						!Input.GetKey (KeyCode.W) &&
						!Input.GetKey (KeyCode.UpArrow) &&
						!Input.GetKey (KeyCode.S) &&
						!Input.GetKey (KeyCode.DownArrow)) {
						movementDirection = Vector2.zero;
				}
				//Sprite walking animations
				int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
				index = index % sprites.Length % 2;
				spriteRenderer.sprite = sprites [directionIndex * 2 + index];
				gameObject.GetComponent<Rigidbody2D> ().velocity = movementDirection * moveSpeed;
		}

		void OnTriggerEnter2D (Collider2D collider)
		{
				if (collider.GetComponent<PhysicsObject> ().ObjectType == PhysicsObjectType.Immovable) {
						transform.position -= (new Vector3 (movementDirection.x, movementDirection.y, 0)) * .3f;
						movementDirection = Vector2.zero;
				}
		}

}
